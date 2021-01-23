    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
			{
			    students.Add(new Student(){FirstName = "First Name - " +i.ToString(),LastName = "Last Name - "+i.ToString()});
			}
            students.Add(new Student() { FirstName = " ", LastName = " " });
            UsingDataSourceAndDataBind(students);
        }
        private void UsingDataSourceAndDataBind(List<Student> students)
        {
            GridView1.DataSource = students;
            GridView1.DataBind();
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
