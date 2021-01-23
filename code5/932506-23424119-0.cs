    using System.Linq;
    // ...
    
    pageItems.ForEach(p => 
    {
        p.Childs = pagesItems.Where(c => c.ParentId == p.Id).ToList();
    });
    
    return pageItems;
