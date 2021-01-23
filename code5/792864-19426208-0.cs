    //Use this Dictionary to get the corresponding delegate for the Where method
    //Suppose your GetBooks() returns a collection of Book elements
    Dictionary<Func<Book,bool>> predicates = new Dictionary<Func<Book,bool>>();
    predicates.Add("ByTitle", b=>b.Title.Contains(searchText));
    predicates.Add("ByISBN", b=>b.ISBN.Contains(searchText));
    predicates.Add("ByTag", b=>b.Tag.Contains(searchText));
    if(comboSelection != ""){
      var result = repository.GetBooks().Where(predicates[comboSelection]);
      //... other code
    }
