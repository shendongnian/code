    POSfinalEntities dbe = new POSfinalEntities();      
    BindingSource bs = new BindingSource();   
    dataProducts.DataSource = null; 
    List<Book> books = dbe.Book.ToList();  
    bs.DataSource = books;
    dataProducts.DataSource = bs;
