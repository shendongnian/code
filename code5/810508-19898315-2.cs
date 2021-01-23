    using(var file = File.OpenRead("booklist.xml"))
    {
        var readBookCollection = (BookList)serializer.Deserialize(file);
    
        foreach (var book in readBookCollection.Books)
        {
            Console.WriteLine("Title: {0}", book.Title);
    
            foreach (var attributePair in book.Attributes)
            {
                Console.CursorLeft = 3;
                Console.WriteLine("Key: {0}, Value: {1}", 
                    attributePair.Key, 
                    attributePair.Value);
            }
        }
    }
