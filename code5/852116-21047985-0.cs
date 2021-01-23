    Step1 s1 = new Step1();
    // ... assign values here ...
    db.Step1s.Add(s1);
    db.SaveChanges();
    
    wizard.Step1Id = s1.Id;
    db.SaveChanges();
