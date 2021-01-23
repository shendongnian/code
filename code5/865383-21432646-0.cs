        public class Student
        {//First create a class to hold your data in
          public string Name { get; set; }
          public string Num { get; set; }
        }
    public class MyForm : Form
    {
        int Index = 0;
        List<Student> FormData { get; set; }
        void GetData()
        {
        //This will hold all your data in memory so you do not have to make a database call each and every "iteration"
        List<Student> dbData = new List<Student>();
        string config = "server=localhost; userid = root; database = databaseName";
            MySqlConnection con = new MySqlConnection(config);
            MySqlDataReader reader = null;
            string query = "SELECT * FROM students";
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student newStudent = new Student();
                newStudent.Name = (string)reader["studentName"];
                newStudent.Num = (string)reader["studentNum"];
                //Add data to the list you created
                dbData.Add(newStudent);          
                .....
            }
            con.Close();
            //set the Form's list equal to the one you just populated
            this.FormData = dbData;
        }
        private void BindData()
        {
            //If winforms
            tbstudentName.Text = FormData[Index].Name;
            tbstudentNum.Text = FormData[Index].Num;
            //If wpf you will have to use view models and bind your data in your XAML but I am assuming you are using
            //winforms here.
        }
        private void NextRecord()
        {    //If you reached the end of the records then this will prevent IndexOutOfRange Exception
            if (Index < FormData.Count - 1)
            {
                Index++;
                BindData();
            }
        }
        private void PreviousRecord()
        {
            if (Index != 0)
            {
                Index--;
                BindData();
            }
        }
    }
  
