    var group = 
    		from book in _xdoc.Root.Elements("book")
    		let date = DateTime.Parse((string) book.Attribute("release_date"))
    		group book by new {date.Year, date.Month}
    		into g
    		select new
    			   {
    				   year = g.Key.Year,
    				   month = g.Key.Month,
    				   books = g.Select(o => new BookList
    										 {
    											 Book_Name = (string) o.Attribute("book_name"),
    											 Release_Date = DateTime.Parse((string) o.Attribute("release_date")),
    											 Book_Store = (string) o.Attribute("Book_Store")
    										 })
    			   };
    foreach (var g in group)
    {
    	Console.WriteLine("Group : {0}, {1}", g.year, g.month);
    	foreach (var book in g.books)
    	{
    		Console.WriteLine("Book Name: {0}. Release Date: {1}. Book Store: {2}", 
    							book.Book_Name, book.Release_Date, book.Book_Store);
    	}
    	Console.WriteLine();
    }
