        var review = (from books in entities.Books.Include("Reviews")
                              where books.Id == 13
                              orderby books.Category
                              select new { books.Reviews }).Single();
        Repeater2.DataSource = review;
        Repeater2.DataBind();
    }
