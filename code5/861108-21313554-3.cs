    internal class Book : NotifyPropertyChangedBase
    {
        private string name;
        private BookType type;
        public BookType Type
        {
           get => this.type;
        }
        set
        {
            this.SetProperty( ref this.type,value );
        }
    }
    public string Name
    {
        get => return this.name;
        set
        {
            this.SetProperty( ref this.name,value );
        }
    }
