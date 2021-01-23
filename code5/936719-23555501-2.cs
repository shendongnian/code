    byte[] imageID = null;               
    using (FileStream fstream = new FileStream(this.pathID.Text, FileMode.Open, FileAccess.Read))
    {
        BinaryReader br = new BinaryReader(fstream);
        imageID = br.ReadBytes((int)fstream.Length); 
        string login = "server=localhost;database=id;uid=root;password=root;";
        using (MySqlConnection conn = new MySqlConnection(login))
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO picture(`Picture_Employee`) VALUES (@EMP);";
            cmd.Parameters.AddWithValue("@EMP", imageID);  
            cmd.ExecuteNonQuery();
            MessageBox.Show("Picture Added");
        }
    
    //sampleID.Text contains ID# of Employee and label1.Text contains the name of the employee
    string newpath = sampleID.Text + "-" + label1.Text;
    System.IO.File.Move(pathID.Text, newpath);
