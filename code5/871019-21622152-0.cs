    public static void TransmitFile(string url)
        {
            string ext = url.Substring(url.LastIndexOf("."), url.Length - url.LastIndexOf("."));
            string filename = url.Substring(url.LastIndexOf("/") + 1, url.Length - ext.Length - url.LastIndexOf("/") - 1).Replace(" ", "_");
            if (filename + ext == url)
            {
                filename = filename.Replace(AppDomain.CurrentDomain.BaseDirectory, "").Replace("\\", "/");
                filename = filename.Substring(filename.LastIndexOf("/") + 1, filename.Length - filename.LastIndexOf("/") - 1);
            }
            if (url.Contains("\\"))
                url = url.Replace(AppDomain.CurrentDomain.BaseDirectory, "").Replace("\\", "/");
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(ext);
            string contentType = key.GetValue("Content Type").ToString();
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = contentType;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + ext);
                HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(url));
                HttpContext.Current.Response.End();
            }
            catch { }
        }
    }
