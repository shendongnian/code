    public bool DeleteRecord(int caurseID)
            {
                studentEntities db = new studentEntities();
    
                var students = db.student.Where(s => s.caurse_id == caurseID);
    
                if(students!=null) db.DeleteAllOnSubmit(students);
                db.SubmitChanges();
                return true;
            }
