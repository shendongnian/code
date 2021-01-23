    A a = null;
    if(User.IsInRole("Role")){
       a = db.A.Find(Id);
    } else {
       a = (from a in db.A
            join b in db.B on a.ID equals b.ID
            join c in db.C on b.ID equals c.ID
            join d in db.D on b.ID equals d.ID
            where a.ID == id && b.Published && c.Published && d.Published
            select a);
    }
    
    if(a == null)
       return NotFound();
        
    return Ok(a);
