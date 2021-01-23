    private void btn_Save_Click(object sender, EventArgs e)
        {
            const string sPath = "save.txt";
    
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);           
           foreach (var item in listBox1.Items)
                {
                     SaveFile.WriteLine(item);
                }
           
            SaveFile.Close();
    
            MessageBox.Show("Programs saved!");
        }
