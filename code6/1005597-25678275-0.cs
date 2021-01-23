    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        //This part will move the file into Archieve folder if the file exist in Cell 2
        if (dataGridView1.Rows[i].Cells[2].Value != null)
        {
             string archievePath = @"C:\user\Archieve\";
             string fileName = archievePath  + Path.GetFileName(dataGridView1.Rows[i].Cells[2].Value.ToString());
             System.IO.File.Move(dataGridView1.Rows[i].Cells[2].Value.ToString(), fileName);
        }
    
        //Now you can continue the process as it was.
        //Move the file from Cell1 to Cell2 directly.
        if (dataGridView1.Rows[i].Cells[1].Value != null)
        {
             //you can change this line to your old logic to generate the new file name.
             string releasePath = @"C:\user\release\";
             string newfileName = releasePath + Path.GetFileName(dataGridView1.Rows[i].Cells[1].Value.ToString());
             System.IO.File.Move(dataGridView1.Rows[i].Cells[1].Value.ToString(), newfileName );
    
             //Delete the file from old location if exist
             if (System.IO.File.Exist(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                  System.IO.File.Delete(dataGridView1.Rows[i].Cells[1].Value.ToString()));
    
             dataGridView1.Rows[i].Cells[2].Value = newfileName;
             dataGridView1.Rows[i].Cells[1].Value = string.Empty;
        }
    }
