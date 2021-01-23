    public interface IBasicTreeItem
    {
        int Id { get; set; }
        string DisplayName { get; set; }
        int? FolderId { get; set; }        
    }
    
    public class BasicTreeItem : IBasicTreeItem 
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int? FolderId { get; set; }        
    }
    
    public class Folder : BasicTreeItem
    {   
        public Folder ParentFolder { get; set; } 
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<File> Files { get; set; }
    
        [NotMapped]
        public ICollection<IBasicTreeItem> Content { get {
           return Files.Concat(Folders).Cast<IBasicTreeItem>();
        } }
    }
    
    public class File : BasicTreeItem
    {
        public Folder ParentFolder { get; set; }
    }
