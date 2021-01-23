    using ( var textReader = new StreamReader("idioms.txt") )
    {
        var idioms = new List<Idiom>();
        string line;
        while ( ( line = textReader.ReadLine() ) != null )
        {
            var idiom = new Idiom();
            if ( line.StartsWith("idiom: ") )
            {
                idiom.Meaning = line.Replace("idiom: ", string.Empty);
                idiom.Description = textReader.ReadLine();
                while ( ( line = textReader.ReadLine() ) != null )
                {
                    if ( line.StartsWith("o ") )
                        idiom.IdiomExamples.Add(new IdiomExample { Item = line.Replace("o ", string.Empty) });
                    else break;
                }
                idioms.Add(idiom);
            }
        }
        ///idioms ready
    }
