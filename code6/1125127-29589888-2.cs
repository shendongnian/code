    public class CompanyPkdClassification 
    {
       public int CompanyId { get; set; }
       public int PkdClassyficationId { get; set; }
       public virtual Company Company { get; set; }
       public virtual Classification Classification { get; set; }
    }
