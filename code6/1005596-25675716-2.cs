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
        string fileName2 = System.IO.Path.GetFileName(filePath2);
        string newpath2 = System.IO.Path.Combine(copyPath, fileName2);
        System.IO.File.Move(filePath2, newpath2);
        dataGridView1.Rows[i].Cells[3].Value = newpath2;
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
