     public IList<ModelSQL.puzzlecontent> GetID(int id)
        {
            return context.puzzlecontents.Where(i => i.WordPuzzleID == id).Select(pc=>new{
                  Column1 = pc.Column1,Column2 = pc.Column2    
            }).Distinct().ToList();
        }
