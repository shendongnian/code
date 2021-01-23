    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
       Student NewStudent = new Student();
       NewStudent.Name = txtName.Text;
       NewStudent.Address = txtAddress.Text;
       NewStudent.Email = txtEmail.Text;
       NewStudent.Matriculationnumber = Convert.ToInt32(txtPayMatNum.Text);
    
       StaticContext.studendList.add(NewStudent);
    }
