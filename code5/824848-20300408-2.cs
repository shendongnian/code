        String path=@"C:\IDFolder";
            
        String [] files= System.IO.Directory.GetFiles(path);
        List<String> ID=new List<string>();
        List<String> Password=new List<string>();
        List<String> Name=new List<string>();
        int count=0;
        int rows = 0;
        foreach (String strFileName in files)
        {
             count = 0;
           String[] allLines = System.IO.File.ReadAllLines(strFileName);
           foreach (String line in allLines)
           {
               dataGridView1.Rows.Add();
               if (allLines[count].Split('/').Length==3)
               {                      
                   dataGridView1.Rows[rows].Cells[0].Value = allLines[count].Split('/')[0];
                   dataGridView1.Rows[rows].Cells[1].Value = allLines[count].Split('/')[1];
                   dataGridView1.Rows[rows].Cells[2].Value = allLines[count].Split('/')[2];
                   count++;
                   rows++;
               }
              
           }
        }
