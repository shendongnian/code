    public static class Extensions
    {
        public static bool hasBackgroundImage(this HtmlElement ele, string cssFolderPath)
        {
            string styleAttr = ele.Style.ToLower();
            if (styleAttr.IndexOf("background-image") != -1 || styleAttr.IndexOf("background") != -1)
            {
                if (styleAttr.IndexOf("url") != -1)
                {
                    return true;
                }
            }
            string[] classes = ele.GetAttribute("className").Split(' ');
            foreach (string className in classes)
            {
                if (className.Trim() == "")
                {
                    continue;
                }
                System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(cssFolderPath);
                foreach (System.IO.FileInfo item in d.GetFiles().Where(p => p.Extension == ".css"))
                {
                    string cssFile = System.IO.File.ReadAllText(item.FullName);
                    int start = cssFile.IndexOf(className);
                    if (start != -1)
                    {
                        string sub = cssFile.Substring(start + className.Length);
                        int end = sub.IndexOf('}');
                        string cssProps = sub.Substring(1, end).Replace("{", "").Replace("}", "").ToLower();
                        if (cssProps.IndexOf("background-image") != -1 || cssProps.IndexOf("background") != -1)
                        {
                            if (cssProps.IndexOf("url") != -1)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
