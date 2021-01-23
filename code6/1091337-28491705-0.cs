    public class ListDetail
    {
       public int ListDetailRowId {get; set;}
    
       public Guid ListDetialId {get; set;}
    
       public Guid ListId {get; set;}
    
       public string Plate {get; set;}
    }    
    
    using(ApplicationDbContext db = new ApplicationDbContext())
        {
           List<ListDetail> results = db.Database.SqlQuery<ListDetail>("SELECT * FROM ListDetails INDEXED BY IX_my_index WHERE ListDetailRowId = @p0", new object[] {50}).ToList();
        
           return results;
        }
