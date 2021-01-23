    [HttpPost]
            public PartialViewResult DBView(string id, string path)
            {
                FileManager FM = new FileManager();
                FM.Path = path;
                if (id != "...")
                {
                    FM.Path =  path + id + "\\";
                }
                else
                {
                    FM.Path = FM.Path.Remove(FM.Path.LastIndexOf("\\"), 1);
                    FM.Path = FM.Path.Remove(FM.Path.LastIndexOf("\\") + 1, y - x - 1);
                }
                return PartialView("CreateDB", FM);
            }
