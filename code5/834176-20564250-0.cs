    var phraseQuery = new PhraseQuery();
    var words = phrase.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var word in words)
    {
        phraseQuery.Add(new Term("Field1", word));
    }
