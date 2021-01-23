    public partial class CustomUpload : LayoutsPageBase
    {
        #region Fields
        private FileUploader uploader;
        #endregion
        #region Properties
        public SPListItem CurrentItem { get; set; }
        public SPContentType ContentType { get; set; }
        public int DocumentID { get; set; }
        private SPList List;
        #endregion
        public CustomUpload()
        {
            SPContext.Current.FormContext.SetFormMode(SPControlMode.New, true);
        }
        protected override void OnInit(EventArgs e)
        {
            if (IsPostBack)
            {
                // Get content type id from query string.
                string contentTypeId = this.Request.QueryString["ContentTypeId"];
                string folder = this.Request.QueryString["RootFolder"];
                //ALL THE MAGIC HAPPENS HERE!!!
                this.uploader = new FileUploader(SPContext.Current.List, this.NewFileUpload, contentTypeId, folder);
                //These event handlers are CRITIAL! They are what enables you to perform the file
                //upload, get the newly created ListItem, DocumentID and MOST IMPORTANTLY...
                //the newly initialized ItemContext!!!
                this.uploader.FileUploading += this.OnFileUploading;
                this.uploader.FileUploaded += this.OnFileUploaded;
                this.uploader.ItemSaving += this.OnItemSaving;
                this.uploader.ItemSaved += this.OnItemSaved;
                this.uploader.TrySaveFile();
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //put in whatever custom code you want...
        }
        protected void OnSaveClicked(object sender, EventArgs e)
        {
            this.Validate();
            var comments = Comments.Text;
            if (this.IsValid && this.uploader.TrySaveItem(true, comments))
            {
                this.uploader.TryRedirect();
            }
            else
            {
                this.uploader.TryDeleteItem();
            }
        }
        private void OnFileUploading(object sender, EventArgs e)
        {
        }
        private void OnFileUploaded(object sender, EventArgs e)
        {
            //This is the next VERY CRITICAL piece of code!!!
            //You need to retrieve a reference to the ItemContext that is created in the FileUploader
            //class and then set your SPListFieldIterator's ItemContext equal to it.
            this.MyListFieldIterator.ItemContext = this.uploader.ItemContext;
            ContentType = this.uploader.ItemContext.ListItem.ContentType;
            this.uploader.ItemContext.FormContext.SetFormMode(SPControlMode.Edit, true);
        }
        private void OnItemSaving(object sender, EventArgs e)
        {
        }
        private void OnItemSaved(object sender, EventArgs e)
        {
            using (new EventFiringScope())
            {
                //This is where you could technically set any values for the ListItem that are
                //not tied into any of your custom fields.
                this.uploader.ItemContext.ListItem.SystemUpdate(false);
            }
        }
    }
