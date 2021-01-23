     public JsonResult GetNodes(string id)
        {
            List<Node> node = new List<Node>();
            List<string> drivers=new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                drivers.AddRange(Directory.GetLogicalDrives());
            }
            else
            {
                if(Directory.Exists(id))
                    drivers.AddRange(Directory.GetDirectories(id));
            }
                try
                {
                    for (int i = 0; i < drivers.Count; i++)
                    {
                        Node item = new Node();
                        DirectoryInfo dirInfo = new DirectoryInfo(drivers[i]);
                        item.id = dirInfo.FullName;
                        item.Name = dirInfo.Name;
                        item.hasChildren = HasNodes(drivers[i]);
                        node.Add(item);
                    }
                }
                catch { }
            return Json(node, JsonRequestBehavior.AllowGet);
        }
