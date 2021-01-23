    public void EditTeacher(Teacher teacher)
    {
        if (teacher == null)
        {
            throw new ArgumentNullException("teacher");
        }
        YourDbContext.Entry(teacher).State = EntityState.Modified;
        // Remove all timetable details that have an orphaned relationship.
        // (E.g., orphaning occurs when 'teacher.TimetableDetails.Clear()'
        //  is called or when you delete one particular TimetableDetail
        //  entity for a teacher)
        YourDbContext.TimetableDetails
            .Local
            .Where(td => td.Teacher == null)
            .ToList()
            .ForEach(td => YourDbContext.TimetableDetails.Remove(td));
        YourDbContext.SaveChanges();
    }
