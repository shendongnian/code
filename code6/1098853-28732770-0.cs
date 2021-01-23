    private void bBrowse_Click(object sender, EventArgs e)
        {
            long size = -1;
            string path = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"; 
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
            openFileDialog1.Title = "Attach speech assessment document";
            openFileDialog1.Filter = "Doc Files|*.doc|Docx File|*.docx|PDF doc|*.pdf";
            openFileDialog1.InitialDirectory = @"C:\";
            fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            path = Path.GetDirectoryName(openFileDialog1.FileName);
            labelFileName.Text = path + "/" + fileName;
        }
        Console.WriteLine(path); // <-- Shows file path in debugging mode.
        Console.WriteLine(result); // <-- For debugging use.
    }
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();
            NetworkCredential nc = new NetworkCredential("username", "password");
            Uri addy = new Uri(@"ftp://url/public_html/assessment/" + fileName);
            client.Credentials = nc;
            byte[] arrReturn = client.UploadFile(addy, labelFileName.Text);
            MessageBox.Show(arrReturn.ToString());
        }
        catch (Exception ex1)
        {
            MessageBox.Show(ex1.Message);
        }
