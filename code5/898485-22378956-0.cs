    public ActionResult SelectGroup(int[] ints)
    {     
       var listToFilter = new HashSet<int>(ints);       
       var list = _bb.MailGroups.Where(m => listToFilter.Contains(m.ID))
                                .SelectMany(m => m.MailLists);
    }
