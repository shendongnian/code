    using (var context = new Context())
    {
        var student2 = context.Students.SingleOrDefault(x=>x.Id == yourID);
    
        student2.Code = "Something";
    
        context.Students.Attach(student2);
        context.Entry(student2).State = EntityState.Modified;
        context.SaveChanges();
    }
