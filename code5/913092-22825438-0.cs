     using (StreamWriter objWriter = new StreamWriter("test1.txt"))
    {
        objWriter.Write(txtName.Text);
        objWriter.Write(txtAddress.Text);
        objWriter.Write(txtEmail.Text);
        objWriter.Write(txtPhone.Text);
        MessageBox.Show("Details have been saved");
    }
