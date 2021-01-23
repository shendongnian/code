    public Bitmap DownloadImage(IntPtr ObjectPointer)
    {
        //get information about image
        EDSDK.EdsDirectoryItemInfo dirInfo = new EDSDK.EdsDirectoryItemInfo();
        this.Parent.Lock(this.Ref);
        lock (LVlock) { Error = EDSDK.EdsGetDirectoryItemInfo(ObjectPointer, out dirInfo); }
        this.Parent.Unlock(this.Ref);
        //check the extension. Raw data cannot be read by the bitmap class
        string ext = Path.GetExtension(dirInfo.szFileName).ToLower();
        
        if (ext == ".jpg" || ext == ".jpeg")
        {
            Bitmap bmp = null;
            this.Parent.Lock(this.Ref);
            lock (LVlock)
            {
                IntPtr streamRef, jpgPointer;
                uint length;
                
                //create memory stream
                Error = EDSDK.EdsCreateMemoryStream(dirInfo.Size, out streamRef);
                //download data to the stream
                DownloadData(ObjectPointer, streamRef);
                Error = EDSDK.EdsGetPointer(streamRef, out jpgPointer);
                Error = EDSDK.EdsGetLength(streamRef, out length);
    
                unsafe
                {
                    //create a System.IO.Stream from the pointer
                    using (UnmanagedMemoryStream ums = new UnmanagedMemoryStream((byte*)jpgPointer.ToPointer(), length, length, FileAccess.Read))
                    {
                        //create bitmap from stream (it's a normal jpeg image)
                        bmp = new Bitmap(ums);
                        //Tentar colocar um dispose no ums aqui
                    }
                }
    
                //release data
                Error = EDSDK.EdsRelease(streamRef);
                //Error = EDSDK.EdsRelease(jpgPointer);
    
                
            }
            this.Parent.Unlock(this.Ref);
            return bmp;
        }
        else
        {
            //if it's a RAW image, cancel the download and release the image
            this.Parent.Lock(this.Ref);
            lock (LVlock)
            {
                Error = EDSDK.EdsDownloadCancel(ObjectPointer);
                Error = EDSDK.EdsRelease(ObjectPointer);
            }
            this.Parent.Unlock(this.Ref);
            return null;
        }
    }
    private void DownloadData(IntPtr ObjectPointer, IntPtr stream)
    {
        
        //get information about the object
        EDSDK.EdsDirectoryItemInfo dirInfo;
        Error = EDSDK.EdsGetDirectoryItemInfo(ObjectPointer, out dirInfo);
    
        try
        {
            //set progress event
            Error = EDSDK.EdsSetProgressCallback(stream, SDKProgressCallbackEvent, EDSDK.EdsProgressOption.Periodically, ObjectPointer);
            //download the data
            Error = EDSDK.EdsDownload(ObjectPointer, dirInfo.Size, stream);
        }
        finally
        {
            //set the download as complete
            Error = EDSDK.EdsDownloadComplete(ObjectPointer);
            //release object
            Error = EDSDK.EdsRelease(ObjectPointer);
        }
        
    }
