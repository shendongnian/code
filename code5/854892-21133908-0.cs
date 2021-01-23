        public List<Student> GetStudentsByCourseName(string courseName)
        {
            var list = new List<Student>();
            var course = db.Courses.SingleOrDefault(o => o.Title == courseName);
            if (course != null)
            {
                list = course.Enrollments.Select(o => new Student {
                        FirstName = o.Student.FirstName,
                        LastName = o.Student.LastName
                    }).ToList();
            }
            return list;
        }
