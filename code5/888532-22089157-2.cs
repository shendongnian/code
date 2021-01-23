    [DataContract]
    public partial class Author
    {
    	[DataMember]
        public int Id { get; set; }
    	[DataMember]
        public string Name { get; set; }
    
    	[DataMember]
        public virtual ICollection<Author_Book> Author_Book { get; set; }
    }
    
    [DataContract]
    public partial class Author_Book
    {
    	[DataMember]
        public int Id { get; set; }
    	[DataMember]
        public int AuthorId { get; set; }
    	[DataMember]
        public string Title { get; set; }
    
    	
        public virtual Author Author { get; set; }
    }
