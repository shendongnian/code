      if (result == DialogResult.OK) // Test result.
      {
            string file = openFileDialog1.FileName;
            DataTable lertableEC0 = new DataTable();
            lertableEC0.ReadXml(openFileDialog1.FileName);       
      }
     else { 
           MessageBox.Show("Error.");
      }
