          public string UniqueName(string name, int parentId)
            {
               var files = allFiles.Where(x => x.ParentId == parentId).ToList();               
                var newName = name;
                if (files.Count() > 0)
                {
                    for (var i = 1; i <= matches; i++)
                    {
                        if (files.Any(x => x.Name == newName 
                            newName = string.Format("{0}({1})", name, i);
                        else
                            return newName 
                    }
                }
                return newName 
        }
