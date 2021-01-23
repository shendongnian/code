    //db.Entry(page).State = EntityState.Modified;
    
   
        db.Attach(page); 
        db.Entry(page).State = EntityState.Unchanged; 
    
        media = db.Pages.Find(page.PageID).Media;
        .
        .
        .
        db.Entry(page).State = EntityState.Modified;
  
    
        db.SaveChanges();
