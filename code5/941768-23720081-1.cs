    using System.Collections.Generic;
    using System.Linq;
    
    namespace XMLStorageAndFilter
    {
    	public class Book
    	{
    		public Book()
    		{
    			Pages = new List<Page>();
    		}
    		public string Title { get; set; }
    		public Author Author { get; set; }
    		public List<Page> Pages { get; set; }
    	}
    	public class Author
    	{
    		public string FirstName { get; set; }
    	}
    	public class Page
    	{
    		public string Heading { get; set; }
    	}
    
    	public class Program2
    	{
    		static void Main()
    		{
    			Page page = new Page();
    			page.Heading = "Heading1";
    			Book bok = new Book();
    			bok.Title = "Title1";
    			bok.Author = new Author() { FirstName = "FirstName1" };
    			bok.Pages.Add(page);
    			List<Book> testList = new List<Book>();
    			testList.Add(bok);
    
    			var searchResult = Search(testList, 
    				title: "Title1",
    				author: "FirstName1",
    				heading: "Heading1");
    		}
    
    		private static IEnumerable<Book> Search(IEnumerable<Book> books, string author = null, string title = null, string heading = null)
    		{
    			return books
    				.Where((b) => SearchByAuthor(b, author))
    				.Where((b) => SearchByHeading(b, heading))
    				.Where((b) => SearchByTitle(b, title))
    				.ToList();
    		}
    
    		private static bool SearchByAuthor(Book b, string author)
    		{
    			if (string.IsNullOrEmpty(author))
    				return true;
    			else
    				return b.Author.FirstName == author;
    		}
    
    		private static bool SearchByTitle(Book b, string title)
    		{
    			if (string.IsNullOrEmpty(title))
    				return true;
    			else
    				return b.Title == title;
    		}
    
    		private static bool SearchByHeading(Book b, string heading)
    		{
    			if (string.IsNullOrEmpty(heading))
    				return true;
    			else
    				return b.Pages.Any(p => p.Heading == heading);
    		}
    	}
    }
