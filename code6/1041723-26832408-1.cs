    void SomeMethod()
    {
        // These are initialized somehow:
        IEnumerable<ContentModel> activeContents = ... ;
        ContentModel contentToAction = ... ;
        int seq = ... ;
        UpdateSequence(activeContents, contentToAction, seq);
    }
    IEnumerable<ContentModel> UpdateSequence(IEnumerable<ContentModel> activeContents,
        ContentModel contentToAction, int seq)
    {
        List<ContentModel> cm = activeContents.ToList();
        cm.Remove(contentToAction);
        contentToAction.seq = seq;
        cm.Add(contentToAction);
    
        return cm.OrderBy(con => con.seq).ToList();
    }
