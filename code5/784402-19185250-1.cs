    OpenFileDialog filedialog = new OpenFileDialog();
    protected void Page_Load(object sender, EventArgs e)
    {
        filedialog.FileOk += filedialog_FileOk;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        filedialog.ShowDialog();        
    }
    void filedialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        using (StreamReader myStream = new StreamReader(filedialog.FileName))
        {
            string line;
            // Read and display lines from the file until the end of  
            // the file is reached. 
            while ((line = myStream.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }
        }
    }
