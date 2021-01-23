    var studentToUpdate=new Student(){Id=id};
    if (TryUpdateModel(studentToUpdate, "",
       new string[] { "LastName", "FirstMidName", "EnrollmentDate" }))
    {
        try
        {
            db.Entry(studentToUpdate).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    ...
    }
