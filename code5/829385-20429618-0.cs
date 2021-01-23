    private void btnDec_Click(object sender, EventArgs e)
        {
            string temp = "";
            int i = 0;
            string listpath = @"c\yearsLog\2015.txt";
            if(!File.FileExists(listpath))
            {
            string writePath = @"c\logs.txt";
            StreamReader file = new StreamReader(listpath);
            long counter = CountLinesInFile(listpath);
            for (i = 0; i < counter; i++)
            {
                temp = file.ReadLine().Replace("....", "");
                CreateNewLogFiles(Decryption(temp),writePath);
            }
            file.Close();
            MessageBox.Show("Log Dosyanız tamamlandı.");
            }
            else
            {
               MessageBox.Show("File "+listpath+" not found");
            }
            
        } 
