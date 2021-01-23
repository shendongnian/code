    Student s = new Student();
    s.Name = _name;
    s.ClassID = _cID;
    
    db.Students.Add(s);
    db.SaveChanges();
    
    //reload the entity from the DB with its associated nav property
    s = db.Students.Include(s=>s.ClassRoom).Single(st=>st.StudentId == s.StudentId);
    ClassRoom c = s.ClassRoom;
