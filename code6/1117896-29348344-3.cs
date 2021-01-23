    public partial class CustomImageControl : UserControl
    {
        [Import]
        public ICachedNameRepository Repo { get; set; }
        private void DynamicImage_PreRender(object sender, EventArgs e)
        {
        }
    }
