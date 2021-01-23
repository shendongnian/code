    public static class FoldersHelper
    {
        public static int ParentFolderCount(string path)
        {
            int parentcnt = 0;
            if (System.IO.Directory.Exists(path))
            {
                string pathroot = Path.GetPathRoot(path);
                path = path.Remove(1, pathroot.Length);
                parentcnt = path.Split('\\').Count()-1;
                return parentcnt;
            }
            else
            {
                throw new Exception("not a folder exception");
            }
            return 0;
        }
        public static int ChildFolderCount(string path)
        {
            int childcnt = 0;
            int maxchild = 0;
            if (System.IO.Directory.Exists(path))
            {
                if (Directory.GetDirectories(path).Length > 0)
                {
                    foreach (string subpath in Directory.GetDirectories(path))
                    {
                        childcnt = ChildFolderCount(subpath) + 1;
                        if (childcnt > maxchild) maxchild = childcnt;
                    }
                }
            }
            else
            {
                throw new Exception("not a folder exception");
            }
            return maxchild;
        }
    }
