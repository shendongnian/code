    var book = new Book();            // Book implements ILocation.
    var person = new Person();        // Person implements ILocation.
    var table = new Table();          // Table doesn't implement ILocation.
    var bookLocation = new Location(1, 2, book);
    var personLocation = new Location(2, 3, person);
    var tableLocation = new Location(2, 3, table);    // Compile error as table doesn't implement ILocation,
