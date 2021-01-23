    private  Student NewStudent { get; set; }
    private void btnset_Click(object sender, RoutedEventArgs e)
    {
        NewStudent = new Student();
        NewStudent.Forename = txtforename.Text;
        NewStudent.Surname = txtsurname.Text;
        NewStudent.Course = txtcourse.Text;
        NewStudent.DoB = txtdob.Text;
        NewStudent.Matriculation = int.Parse(txtmatric.Text);
        NewStudent.YearM = int.Parse(txtyearm.Text);
    }
