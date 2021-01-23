    var mainClass = new Searchables();
 
    ....
    mainClass.SearchContent((status, searchee, property) =>
        {
            switch(status)
            {
                case Status.Delete:
                    // DoSomthing1 ...
                    break;
            }
        });
