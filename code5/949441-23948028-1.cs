    DataTable dt = new DataTable();
    dt.Columns.Add("SubjectID", typeof(int));
    dt.Columns.Add("StudentName", typeof(string));
    // or you can just clone existing DataTable:
    DataTable dt = dtFiles.Clone();
    foreach(var subject in subjects)
       dt.Add(subject.ID, subject.Students);  
