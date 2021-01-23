    var dates = (from bookdetails in bookcategories
             where SqlFunctions.IsDate(bookdetails.PublishedDate)==1
             orderby bookdetails.PublishedDate descending, bookdetails.BookId)
             .ToList()
             .Where.(b=> Convert.ToDateTime(b.PublishedDate) >= twomonths 
                     && Convert.ToDateTime(b.PublishedDate) <= today);
