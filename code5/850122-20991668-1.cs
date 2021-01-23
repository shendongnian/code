        if(MessageBox.Show("Delete All Text Files?", "Delete Verification"
          , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            string[] filePaths = System.IO.Directory.GetFiles(@"C:\test\", "*.txt");
            foreach (string filePath in filePaths)
            
                System.IO.File.Delete(filePath);
        }
