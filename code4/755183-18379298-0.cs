    [HttpGet]
    public ActionResult GetImage(int id)
    {
        byte[] buffer;
        if (HttpContext.Cache["image_" + id] == null)
        {
            var dbMediaItem = m_database.MediaItems.Single(i => i.Id.Equals(id));
            string path = string.Format(Server.MapPath("~/{base path}/{0}"), dbMediaItem.Filename);
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                HttpContext.Cache.Add("image_" + id, Convert.ToBase64String(buffer), null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), CacheItemPriority.Normal, null);
            }
        }
        else
        {
            buffer = Convert.FromBase64String(HttpContext.Cache["image_" + id].ToString());
        }
        return base.File(buffer, "image/png");
    }
