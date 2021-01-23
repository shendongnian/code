    public class AddColumn
    {
        internal AddColumn()
        {
            
        } 
        public NamedAddColumn Named(string name)
        {
            return new NamedAddColumn(name);
        }
    }
    public class NamedAddColumn
    {
        protected string Name {get; set;}
        internal NamedAddColumn(string name)
        {
            Name = name;
        }
        public VarcharTypedAddColumn Varchar
        {
            get
            {
                return new VarcharTypedAddColumn(Name);
            }
        }
    }
