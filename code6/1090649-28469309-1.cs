    public class Document
    {
    	public int Id { get; set; }
    	public string Name { get; set; }	
    	public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
    }
    
    public class UploadedFile
    {
    	public int Id { get; set; }
    	public string FileName { get; set; }
    	public string EntityName { get; set; }
    	public int EntityId { get; set; }
    	public bool IsActive { get; set; }
    }
