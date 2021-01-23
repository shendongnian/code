    List<Double> GetTuitionsById(List<Student> students)
    {
        var ids = students.Select(x => x.Id).ToList();
        // return Id and tuition
        var query = from dbStudent in _context.StudentsDB
                    where ids.Contains(dbStudent.Id)
                    select new { dbStudent.Id, dbStudent.Tuition};  
        var tuitions = query.AsEnumerable().ToDictionary(s => s.Id, s => x.Tuition);
        var results = List<double>();
        foreach(var student in students)
        {
            // below is assumed that every student has tuition returned from the database
            results.Add(tuitions[student.Id]);
        }
        return results;
    }
