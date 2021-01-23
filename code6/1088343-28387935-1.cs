        public static Dictionary<ClassLevel, int> StudentsPerClassLevel(this IEnumerable<Student> students)
        {
            return students.GroupBy(student => student.ClassLevel, 
                (level, s) => new Tuple<ClassLevel, int>(level, s.Count())).ToDictionary(t => t.Item1, t => t.Item2);
        }
