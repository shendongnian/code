    var filteredLibrary = new Library("filteredLibrary");
    foreach (var section in 
            from section in library.Sections 
            from book in section.Books 
            from word in book.Words 
            let chars = word.Characters
                            .Where(c => c.chrctr == 'd')
                            .ToList() 
            where chars.Count > 0
            select section)
    {
        //if it doesn't exist
        filteredLibrary.Sections.Add(section);  
        filteredLibrary.GetSection(section.Name).Books.Add(book);
        filteredLibrary.GetSection(section.Name).GetBook(book.Name).Words.Add(chars);
    }
