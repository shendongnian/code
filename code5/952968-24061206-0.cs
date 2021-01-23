    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        #region Methods
        public void AddViewLocationFormat(string paths)
        {
            var existingPaths = new List<string>(ViewLocationFormats) {paths};
            ViewLocationFormats = existingPaths.ToArray();
        }
        public void AddPartialViewLocationFormat(string paths)
        {
            var existingPaths = new List<string>(PartialViewLocationFormats) {paths};
            PartialViewLocationFormats = existingPaths.ToArray();
        }
        #endregion
    }
