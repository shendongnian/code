    public class FileUploader
    {
        #region Fields
        private readonly SPList list;
        private readonly FileUpload fileUpload;
        private string contentTypeId;
        private string folder;
        private SPContext itemContext;
        private int itemId;
        #endregion
        #region Properties
        public bool IsUploaded
        {
            get
            {
                return this.itemId > 0;
            }
        }
        public SPContext ItemContext
        {
            get
            {
                return this.itemContext;
            }
        }
        public int ItemId
        {
            get
            {
                return this.itemId;
            }
        }
        public string Folder
        {
            get
            {
                return this.folder;
            }
            set
            {
                this.folder = value;
            }
        }
        public string ContentTypeId
        {
            get
            {
                return this.contentTypeId;
            }
            set
            {
                this.contentTypeId = value;
            }
        }
        #endregion
        public FileUploader(SPList list, FileUpload fileUpload, string contentTypeId)
        {
            this.list = list;
            this.fileUpload = fileUpload;
            this.contentTypeId = contentTypeId;
        }
        public FileUploader(SPList list, FileUpload fileUpload, string contentTypeId, string folder)
        {
            this.list = list;
            this.fileUpload = fileUpload;
            this.contentTypeId = contentTypeId;
            this.folder = folder;
        }
        public event EventHandler FileUploading;
        public event EventHandler FileUploaded;
        public event EventHandler ItemSaving;
        public event EventHandler ItemSaved;
        public void ResetItemContext()
        {
            //This part here is VERY, VERY important!!!
            //This is where you "trick/hack" the SPContext by setting it's mode to "edit" instead
            //of "new" which gives you the ability to essentially initialize the
            //SPContext.Current.ListItem and set it's ItemId value. This of course could not have
            //been accomplished before because in "new" mode there is no ListItem. 
            //Once you've done all that then you can set the FileUpload.itemContext 
            //equal to the SPContext.Current.ItemContext. 
            if (this.IsUploaded)
            {
                SPContext.Current.FormContext.SetFormMode(SPControlMode.Edit, true);
                SPContext.Current.ResetItem();
                SPContext.Current.ItemId = itemId;
                this.itemContext = SPContext.Current;
            }
        }
        public bool TryRedirect()
        {
            try
            {
                if (this.itemContext != null && this.itemContext.Item != null)
                {
                    return SPUtility.Redirect(this.ItemContext.RootFolderUrl, SPRedirectFlags.UseSource, HttpContext.Current);
                }
            }
            catch (Exception ex)
            {
                // do something
                throw ex;
            }
            finally
            {
            }
            return false;
        }
        public bool TrySaveItem(bool uploadMode, string comments)
        {
            bool saved = false;
            try
            {
                if (this.IsUploaded)
                {
                    //The SaveButton has a static method called "SaveItem()" which you can use
                    //to kick the whole save process into high gear. Just right-click the method
                    //in Visuak Studio and select "Go to Definition" in the context menu to see
                    //all of the juicy details.
                    saved = SaveButton.SaveItem(this.ItemContext, uploadMode, comments);
                    if (saved)
                    {
                        this.OnItemSaved();
                    }
                }
            }
            catch (Exception ex)
            {
                // do something
                throw ex;
            }
            finally
            {
            }
            return saved;
        }
        public bool TrySaveFile()
        {
            if (this.fileUpload.HasFile)
            {
                using (Stream uploadStream = this.fileUpload.FileContent)
                {
                    this.OnFileUploading();
                    var originalFileName = this.fileUpload.FileName;
                    SPFile file = UploadFile(originalFileName, uploadStream);
                    var extension = Path.GetExtension(this.fileUpload.FileName);
                    this.itemId = file.Item.ID;
                    
                    using (new EventFiringScope())
                    {
                        file.Item[SPBuiltInFieldId.ContentTypeId] = this.ContentTypeId;
                        file.Item.SystemUpdate(false);
                        //This code is used to guarantee that the file has a unique name.
                        var newFileName = String.Format("File{0}{1}", this.itemId, extension);
                        Folder = GetTargetFolder(file.Item);
                        if (!String.IsNullOrEmpty(Folder))
                        {
                            file.MoveTo(String.Format("{0}/{1}", Folder, newFileName));
                        }
                        file.Item.SystemUpdate(false);
                    }
                    this.ResetItemContext();
                    this.itemContext = SPContext.GetContext(HttpContext.Current, this.itemId, list.ID, list.ParentWeb);
                    this.OnFileUploaded();
                    return true;
                }
            }
            return false;
        }
        public bool TryDeleteItem()
        {
            if (this.itemContext != null && this.itemContext.Item != null)
            {
                this.ItemContext.Item.Delete();
                return true;
            }
            return false;
        }
        private SPFile UploadFile(string fileName, Stream uploadStream)
        {
            SPList list = SPContext.Current.List;
            if (list == null)
            {
                throw new InvalidOperationException("The list or root folder is not specified.");
            }
            SPWeb web = SPContext.Current.Web;
            SPFile file = list.RootFolder.Files.Add(fileName, uploadStream, true);
            
            return file;
        }
        private string GetTargetFolder(SPListItem item)
        {
            var web = item.Web;
            var rootFolder = item.ParentList.RootFolder.ServerRelativeUrl;
            var subFolder = GetSubFolderBasedOnContentType(item[SPBuiltInFieldId.ContentTypeId]);
            var folderPath = String.Format(@"{0}/{1}", rootFolder, subFolder);
            var fileFolder = web.GetFolder(folderPath);
            if (fileFolder.Exists) return folderPath;
            return Folder;
        }
        private void OnFileUploading()
        {
            EventHandler handler = this.FileUploading;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        private void OnFileUploaded()
        {
            EventHandler handler = this.FileUploaded;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        private void OnItemSaving()
        {
            EventHandler handler = this.ItemSaving;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        private void OnItemSaved()
        {
            EventHandler handler = this.ItemSaved;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
