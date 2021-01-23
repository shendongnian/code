     DialogResult res = MessageBox.Show("Delete All Text Files?", "Delete Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
     if( res == DialogResult.Yes)
     {
        System.IO.File.Delete(filePath);
     }
