        public void RetrieveCourses()
        {
            // Query database
            using(var context = new TAModelContainer())
            {
                var data = context.Courses.ToList<Course>();
                foreach (Course course in data)
                {
                    _courses.Add(course);
                }
            }
        }
