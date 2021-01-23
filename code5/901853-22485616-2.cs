    class FileRoutines
    {
        public static Students LoadStudents(string path)
        {
            var lines = File.ReadLines(path);
            var students = lines.Select(l => l.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                .Select(split => new Student 
                                 { 
                                     Id = split[0], 
                                     LastName = split[1], 
                                     FirstName = split[2] 
                                 });
            return new Students(students);
        }
    }
