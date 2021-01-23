    class AssociationUriMapper : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            strUri = uri.ToString();
    
            // File association launch
            if (strUri.Contains("/FileTypeAssociation"))
            {
                // Get the file ID (after "fileToken=").
                int nFileIDIndex = strUri.IndexOf("fileToken=") + 10;
                string strFileID = strUri.Substring(nFileIDIndex);
    
                string strFileName = SharedStorageAccessManager.GetSharedFileName(strFileID);
                string strIncomingFileType = Path.GetExtension(strFileName);
    
                string strData = fnCopyToLocalFolderAndReadContents(strFileID).Result;
    
                switch (fileType)
                {
                    case ".gmm":
                           //determine if gmm is text
                           if (objGMM.fnGetGMMType() == GMMFILETYPE.TXT)
                           {
                               return new Uri("/PageReadText.xaml?data=" + strData, UriKind.Relative);
                           }
                           break;
                 }
            }
      }
    
      async Task<string> fnCopyToLocalFolderAndReadContents(string strIncomingFileId)
      {
         StorageFolder objLocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
         objFile = await SharedStorageAccessManager.CopySharedFileAsync(objLocalFolder, TEMP.gmm, NameCollisionOption.ReplaceExisting, strIncomingFileId).ConfigureAwait(false);
    
         using (StreamReader streamReader = new StreamReader(objFile))
         {
            return streamReader.ReadToEnd();
         }
      }
    }
