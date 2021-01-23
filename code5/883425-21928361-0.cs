    if (!String.IsNullOrEmpty(searchTagName))
    {
       Articles = Articles.Where(b => 
                        b.Tag1.Contains(searchTagName) 
                     || b.Tag2.Contains(searchTagName) 
                     || b.Tag3.Contains(searchTagName) 
                     || b.Tag4.Contains(searchTagName));
    }
