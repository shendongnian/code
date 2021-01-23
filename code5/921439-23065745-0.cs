    public class Folder
    {
        public Folder Parent{get;set;}
        public int ID { get; set; }
        private List<Folder> children { get; set; }
        public ReadOnlyCollection<Folder> Children { get { return children.AsReadOnly();}
        public void AddChildern(Folder child)
        {
           child.Parent = this;
           children.Add(child);
        }
       
        public void RemoveChildren(Folder child)
        {
           ...
        }
    }
