    string filePath = dataGridView1.Rows[i].Cells[3].Value.ToString();
    if (System.IO.File.Exists(filePath))
    {
      // First move the Cell2 file to 'Archieve'
      string replacepath = @"C:\user\Archieve";
      string fileName = System.IO.Path.GetFileName(filePath);
      string newpath = System.IO.Path.Combine(replacepath, fileName);
      System.IO.File.Move(filePath, newpath);
      // Then moving Cell1 file to 'Release', replace Cell2 and clear Cell1
      string filePath2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
      if (System.IO.File.Exists(filePath2))
      {
        string fileName = System.IO.Path.GetFileName(filePath2);
        string newpath = System.IO.Path.Combine(copyPath, fileName);
        System.IO.File.Move(filePath2, newpath);
        dataGridView1.Rows[i].Cells[3].Value = newpath;
        try
        { 
          ///codes to update in databse
        }
        catch (System.Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      dataGridView1.Rows[i].Cells[2].Value = string.Empty;
    }
