    using (StreamWriter objWriter = new StreamWriter(file_name, true))
    {
        objWriter.Write(txtName.Text);
        objWriter.Write(txtAddress.Text);
        objWriter.Write(txtEmail.Text);
        objWriter.Write(txtPhone.Text);
    }
