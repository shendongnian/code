     string name = txtName.Text;
     int id = Int32.Parse(txtID.Text);
     decimal gpa = decimal.Parse(txtGPA.Text);
     int studentNumber = listofStudents.Count() + 1;
     Student student = new Student(name, id, gpa, studentNumber);
     listofStudents.Add(student);
