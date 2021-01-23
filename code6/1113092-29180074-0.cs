     List<Double> GetTuitionsById(List<Student> students)
        {
         List<Double> objRes=new List<Double>();
            var ids = students.Select(x => x.Id).ToList();
            var query = (from dbStudent in _context.StudentsDB
                        where ids.Contains(dbStudent.Id)
                        select dbStudent.Tuition).ToLIst();
             foreach(var x in query )
             {
              objRes.Add(Double.Parse(x));
             }
    
            return objRes;
        }
