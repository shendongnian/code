        public IE_TeamMentor(string webRoot, string path_XmlLibraries, Uri siteUri, bool startHidden)
        {
            this.ie                = "Test_IE_TeamMentor".popupWindow(1000,700,startHidden).add_IE();            
            this.path_XmlLibraries = path_XmlLibraries;
            this.webRoot           = webRoot;
            this.siteUri           = siteUri;
        }
