You're passing the whole collection remoteDir into the DownloadFile method, which looks like this:
    // AppLimit.CloudComputing.SharpBox.CloudStorage
    public void DownloadFile(ICloudDirectoryEntry parent, string name, string targetPath, FileOperationProgressChanged delProgress)
    {
    	if (parent == null || name == null || targetPath == null)
    	{
    		throw new SharpBoxException(SharpBoxErrorCodes.ErrorInvalidParameters);
    	}
    	targetPath = Environment.ExpandEnvironmentVariables(targetPath);
    	ICloudFileSystemEntry child = parent.GetChild(name);
    	using (FileStream fileStream = new FileStream(Path.Combine(targetPath, name), FileMode.Create, FileAccess.Write, FileShare.None))
    	{
    		child.GetDataTransferAccessor().Transfer(fileStream, nTransferDirection.nDownload, delProgress, null);
    	}
    }
The only point at which parent could be modified in this method seems to be where it calls GetChild. Looking at GetChild (I used IlSpy):
    public ICloudFileSystemEntry GetChild(string name)
    {
      return this.GetChild(name, true);
    }
    
    public ICloudFileSystemEntry GetChild(string name, bool bThrowException)
    {
      this.RefreshResource();
      ICloudFileSystemEntry cloudFileSystemEntry;
      this._subDirectories.TryGetValue(name, out cloudFileSystemEntry);
      if (cloudFileSystemEntry == null && bThrowException)
      {
        throw new SharpBoxException(SharpBoxErrorCodes.ErrorFileNotFound);
      }
      return cloudFileSystemEntry;
    }
This, in turn, calls RefreshResource on the collection. Which looks like this (have assumed the dropbox implementation):
    // AppLimit.CloudComputing.SharpBox.StorageProvider.BaseObjects.BaseDirectoryEntry
    private void RefreshResource()
    {
    	this._service.RefreshResource(this._session, this);
    	this._subDirectoriesRefreshedInitially = true;
    }
    
    
    // AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox.Logic.DropBoxStorageProviderService
    public override void RefreshResource(IStorageProviderSession session, ICloudFileSystemEntry resource)
    {
    	string resourceUrlInternal = this.GetResourceUrlInternal(session, resource);
    	int num;
    	string text = DropBoxRequestParser.RequestResourceByUrl(resourceUrlInternal, this, session, out num);
    	if (text.Length == 0)
    	{
    		throw new SharpBoxException(SharpBoxErrorCodes.ErrorCouldNotRetrieveDirectoryList);
    	}
    	DropBoxRequestParser.UpdateObjectFromJsonString(text, resource as BaseFileEntry, this, session);
    }
Now, this then calls UpdateObjectFromJsonString (which I'm not going to paste here because it's huge), but this then seems to update the resource object which belongs to the collection. Hence your collection gets changed... and your exception.
