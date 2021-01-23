    class MyObject
    {
        // lots of fields painful to initialize all at once
        // so we make fields mutable :
        public String Title { get; protected set; }
        public String Author { get; protected set; }
        // ...
        public MyObject(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
