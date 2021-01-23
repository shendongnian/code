        [HttpGet]
        [OutputCache(VaryByCustom="id")]
        public void DownloadFile(int id)
        {
            var path = GetFilePath(id);
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=xxx");
            Response.WriteFile(path);
            Response.End();
        }
