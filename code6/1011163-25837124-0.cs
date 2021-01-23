    var dictNote = Note.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    var dictNews = Newspaper.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    
    bool contains = dictNote.All(x => 
        dictNews.ContainsKey(x.Key) && x.Value <= dictNews[x.Key]);
