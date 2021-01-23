    public static class DataExtensions
    {
        private static readonly Random _random = new Random();
        
        public static void Normalize(this List<Student> students)
        {
            for(int i=0; i<students.Count; i++)
            {
                students[i].Normalize();
            }
        }
        public static void Normalize(this Student student)
        {
            if(student.Group == 0)
                student.Group = _random.Next();
            if(student.Priority == 0)
                student.Priority = _random.Next();
        }
    }
