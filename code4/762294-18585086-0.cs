    public IList<ModelSQL.puzzlecontent> GetID(int id)
    {
       //for grouping by multiple properties you can use Groupby like
       // .GroupBy(i=>new { i.WordPuzzleID,i.SecondProperty})
       return context.puzzlecontents
                     .Where(i => i.WordPuzzleID == id)
                     .GroupBy(i=>i.WordPuzzleID)
                     .Select(g=>g.First()).ToList();
    }
