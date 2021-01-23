        [HttpGet]
        public ContentResult GetTitle(string type)
        {
            string titleString = getStringFromByte(this.DataProvider.CustomizationFileManager.LoadCustomizationFile("WebsitePageTitle.txt"));
            if (titleString != null && titleString.Length > 0)
                return Content(titleString);
            else
                return Content("");
        }
