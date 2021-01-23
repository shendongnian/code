    db.Save(row, references: true);
    
    row.PrintDump();
    
    Assert.That(row.Id, Is.EqualTo(1));
    Assert.That(row.Child1Id, Is.EqualTo(1));
    Assert.That(row.Child1.Id, Is.EqualTo(1));
    Assert.That(row.Child1.Name, Is.EqualTo("Child 1"));
    Assert.That(row.Child2Id, Is.EqualTo(2));
    Assert.That(row.Child2.Id, Is.EqualTo(2));
    Assert.That(row.Child2.Name, Is.EqualTo("Child 2"));
    
