    List<int> ids;
    using (var context = new Context())
    {
        ids = (
            from f in context.Files
            from a in context.AFiles
            from b in context.BFiles
            where a.FileId != f.FileId && b.FileId != f.FileId
            select f.FileId).ToList();
    }
    public class File {
        [Key] public int FileId { get; set; }    
    }
    public class AFile {
        [Key] public int AFileId { get; set; }
        [ForeignKey("File")]
        public int FileId { get; set; }
        public virtual File File { get; set; }    
    }
    public class BFile {
        [Key] public int BFileId { get; set; }
        [ForeignKey("File")]
        public int FileId { get; set; }
        public virtual File File { get; set; }
    }
    public class Context : DbContext {
        public DbSet<File> Files { get; set; }
        public DbSet<AFile> AFiles { get; set; }
        public DbSet<BFile> BFiles { get; set; }
    }
