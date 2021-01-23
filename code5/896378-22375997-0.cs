    [DataContract]
    public class BookData
    {
        [DataMember]
        public string BookCoverPath { get; set; }
        
        [IgnoreDataMember]
        public BitmapImage Image { get; set; }
    }
    public BookDataList LoadList()
    {
      var booklist = loadAndDeserializeFromXML();
      return booklist == null 
        ? null 
        : this.WithBitmaps(booklist );
    }
    private BookDataList WithBitmaps(BookDataList bookData)
    {
      bookData.BookData.ForEach(b =>
      {
        b.Image= loadPicture(b.BookCoverPath );
      });               
      return bookData;
    }
