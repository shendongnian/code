    // Your select then becomes:
    var newAnswers = from spec in Db.Questions
                     from ans in db.Answers
                     where ans.in_Id == spec.in_Id
                     select new SheetAns()
                     {
                         in_SheetID = prod.in_SheetID
                         in_AnswerID = ans
                            .OrderBy(x => Guid.NewGuid()) // can't "ORDER BY NEWID()" in linq.
                            .Select(x => x.in_AnswerID)
                            .FirstOrDefault())
                     };
    // Now add them. This is still going to be slow, because entity framework
    // does not support bulk inserts.
    db.SheetAns.AddRange(newAnswers);
    db.SaveChanges();
    
