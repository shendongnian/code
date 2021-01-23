        [HttpGet]
        [OutputCache(VaryByCustom="id")]
        public void DownloadFile(int id)
        {
            path = GetFilePath(id);
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=xxx");
            Response.WriteFile(path);
            Response.End();
        }
