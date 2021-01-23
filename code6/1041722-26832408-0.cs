    void SomeMethod()
    {
        // These are initialized somehow:
        IEnumerable<ContentModel> activeContents = ... ;
        ContentModel contentToAction = ... ;
        int seq = ... ;
        UpdateSequence(activeContents, contentToAction, seq);
    }
    void UpdateSequence(IEnumerable<ContentModel> activeContents,
        ContentModel activeContents, int seq)
    {
        ContentModel ActiveContent = contentToAction;
        List<ContentModel> cm = activeContents.ToList();
        cm.Remove(ActiveContent);
        ActiveContent.seq = seq;
        cm.Add(ActiveContent);
    
        activeContents = null; // superfluous in any case
        activeContents = cm;   // ditto here
        activeContents = activeContents.OrderBy(con => con.seq);
    }
