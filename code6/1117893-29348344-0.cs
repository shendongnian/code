    public partial class CustomImageControl : UserControl
    {
        [Import]
        public ICachedNameRepository Repo { get; set; } // Null reference here
        private void DynamicImage_PreRender(object sender, EventArgs e)
        {
            ImageUrl = { some ICachedNameRepository usage }
        }
    }
