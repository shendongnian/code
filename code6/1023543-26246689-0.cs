        private List<Course> Courses = new List<Course>();
        public Form1()
        {
            InitializeComponent();
            
            Courses.Add(new Course("Computer Science",1));   
            Courses.Add(new Course("English", 2));
            Courses.Add(new Course("Art", 3));
            Courses.Add(new Course("Biology", 4));
            Courses.Add(new Course("Philosophy", 5));
            Courses.Add(new Course("Humanities", 6));
            CourseCB.DataSource = Courses;
            CourseCB.SelectedText = Courses.ElementAt(0).CourseName;
            CourseCB.DisplayMember = "CourseName";
            CourseCB.ValueMember = "CourseID";
        }
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (CourseCB.SelectedIndex != -1)
            {
                CourseIDTB.Text = CourseCB.SelectedValue.ToString();
            }
        }
        public class Course
        {
            private string myCourseName;
            private int myCourseID;
            public string CourseName
            {
                get { return this.myCourseName; }
                set { this.myCourseName = value; }
            }
            public int CourseID
            {
                get { return this.myCourseID; }
                set { this.myCourseID = value; }
            }
            public Course(string name, int ID)
            {
                this.CourseName = name;
                this.CourseID = ID;
            }
        }
