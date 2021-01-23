        [HttpGet]
        public IList<string> GetFolderNames(int id)
        {
            //FIND ALL FOLDERS IN FOLDER 
            string location = System.Web.HttpContext.Current.Server.MapPath("parent folder name");
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(location);
            var folderList = new List<string>();
            foreach (System.IO.DirectoryInfo g in dir.GetDirectories())
            {
                //LOAD FOLDERS 
                folderList.Add(g.FullName);
            }
            return folderList;
        }
