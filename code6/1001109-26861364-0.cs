    public class Author {
		public string Name { get; set; }
	}
	public class Book {
		public string Title { get; set; }
		public Author Author { get; set; }
	}
	public class BookDTO {
		public string Title { get; set; }
		public string Author { get; set; }
	}
