    public static void TransmitFile(Page CurrentPage, string FilePath)
    // CurrentPage = this when called from CodeBehind
    {
        if (File.Exists(FilePath))
        {
            string FileName = Path.GetFileName(FilePath);
            string Extension = Path.GetExtension(FilePath).ToLowerInvariant();
            string ContentType;
            switch (Extension)
            {
                case "xlsx":
                    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "xls":
                    ContentType = "application/vnd.ms-excel";
                    break;
                case "csv":
                    ContentType = "text/csv";
                    break;
                default:
                    ContentType = "application/octet-stream";
                    break;
            }
            if (CurrentPage != null)
            {
                CurrentPage.Response.ContentType = ContentType;
                CurrentPage.Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
                CurrentPage.Response.TransmitFile(FilePath);
                CurrentPage.Response.End();
            }
            else
                throw new Exception("File transmission failed: cannot access current page");
        }
        else
            throw new Exception("File transmission failed: file not found");
    }
