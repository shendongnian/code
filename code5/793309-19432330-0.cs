        [Table("Document")]
        public class Document
        {
            [Key]
            [ForeignKey("Data")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DocumentId { get; set; }
            public string FileName { get; set; }
            public DateTime Created { get; set; }
            public virtual DocumentData Data { get; set; }
        }
        [Table("Document")]
        public class DocumentData
        {
            [Key]
            [ForeignKey("Document")]
            public int DocumentId { get; set; }
            public byte[] Data { get; set; }
            public virtual Document Document { get; set; }
        }
        public class DocEntities : DbContext
        {
            public DocEntities()
                : base("name=TestEntitiesCodeFirst")
            {
            }
            public DbSet<Document> Documents { get; set; }
        }
        static void Main(string[] args)
        {
            using (var db = new InheritTest.DocEntities())
            {
                var doc = new Document()
                {
                    Created = DateTime.Now,
                    FileName = "Abc.txt",
                    Data = new DocumentData()
                    {
                        Data = new byte[] { 0x50, 0x51, 0x52, 0x53 }
                    }
                };
                db.Documents.Add(doc);
                db.SaveChanges();
            }
            
            using (var db = new InheritTest.DocEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var doc = db.Documents.First();
                if (doc.Data == null)
                {
                    Console.WriteLine("doc.Data is null");
                }
                db.Entry(doc).Reference(p => p.Data).Load();
                if (doc.Data != null)
                {
                    Console.WriteLine("doc.Data is not null");
                }
            }
            var input = Console.ReadLine();
        }
