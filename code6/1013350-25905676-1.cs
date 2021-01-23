            protected void Page_Load(object sender, EventArgs e)
        {
            RptCourse.DataSource = GetCourses();
            RptCourse.DataBind();
        }
        private List<Course> GetCourses()
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=tafe_work;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("select * from Course", sqlConnection))
                {
                    using (var sqlReader = sqlCommand.ExecuteReader())
                    {
                        dataTable.Load(sqlReader);
                    }
                }
            }
            var courses = new List<Course>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var course = new Course()
                {
                    ID = (int)dataRow["Course_ID"],
                    Name = (string)dataRow["Name"]
                };
                courses.Add(course);
            }
            return courses;
        }
    }
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
