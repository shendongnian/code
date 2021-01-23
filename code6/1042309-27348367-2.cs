    public class FileResultDto
    {
        public string FileName {get;set;}
        public string FileSize {get;set;}
    }
    
    var query = "SELECT f.FileName, f.FileSize" +
                "FROM Files f" +
                "INNER JOIN FileTree ft ON ft.FolderID = f.FolderID" +
                "INNER JOIN AspNetUsers u ON ft.UserID = u.Id" +
                "WHERE u.id = @id AND ft.FolderPath = @path;";
    
    var userIdParam = new SqlParameter("id", userId);
    var pathParam = new SqlParameter("path", path);
    
    var result = context.Database.SqlQuery<FileResultDto>(query, userIdParam, pathParam);
