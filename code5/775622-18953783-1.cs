    public class LeftJoinIndex : AbstractMultiMapIndexCreationTask<LeftJoinIndex.ReduceResult>
    {
        public class ReduceResult
        {
            public string TeacherName;
            public string[] Students;
        }
        public LeftJoinIndex()
        {
            AddMap<Students>(studentsList =>
                            from list in studentsList
                            from student in list.List
                            select new
                                {
                                    TeacherName = student.HomeRoomTeacher,
                                    Students = new[] { student.Name }
                                }
                );
            AddMap<Teachers>(teacherLists =>
                            from list in teacherLists
                            from teacher in list.List
                            select new
                                {
                                    TeacherName = teacher.Name,
                                    Students = new string[0]
                                }
            );
            Reduce = results =>
                     from reduceResult in results
                     group reduceResult by reduceResult.TeacherName
                         into g
                         select new
                             {
                                 TeacherName = g.Key,
                                 Students = g.SelectMany(x => x.Students)
                             };
        }
    }
