    private async Task Search(string text)
    {
        // execute the LINQ query with the TPL
        List<Word> words = await Database.connection.Table<Word>().Where(x => x.word == text).ToListAsync();
    
        // we are back on the UI thread
        foreach(Word word in words)
        {
            // do something
        }
    }
