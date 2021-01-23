    private void button1_Click(object sender, EventArgs e)
    {
        // Select the output file
        openFileDialog1.ShowDialog();
        sfname = openFileDialog1.FileName;
        // Create an output stream with this file
        fsrw = new FileStream(sfname, FileMode.Open);
        // Read your image
        bytearray = File.ReadAllBytes(fname);
        // Write the array to the outputStream
        fsrw.Write(bytearray, 0, bytearray.Length);
        fsrw.Close();
        MessageBox.Show("success");
    }
