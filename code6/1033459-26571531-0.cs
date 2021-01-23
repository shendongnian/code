    public static List<Word> GetWords(string word_Fa, string word_En)
    {
        var db = Global.GetEntitiy();
        return db.Words
                    .Where(w => w.Word_Fa.Intersect(word_Fa.Split(' ')).Any() ||
                                w.Word_En.Intersect(word_En.Split(' ')).Any())
                    .ToList();
    }
