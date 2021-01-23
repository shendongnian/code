    public void WriteToTextFile (DataGridView dgv)
    {
    	String file_name = "D:\\test1.txt";
    	using (StreamWriter objWriter = new StreamWriter(file_name))
        {
    		for (Int32 row = 0; row < dgv.Rows.Count - 1; row++)
    		{
    		    StringBuilder sb = new StringBuilder();
    			for ( Int32 col = 0; col < dgv.Rows[row].Cells.Count - 1; col++)  
    			{
    			    if (!String.IsNullOrEmpty(sb.ToString()))
    				    sb.Append(",");
    				sb.Append(dgv.Rows[row].Cells[col].Value.ToString());
    			}
    			objWriter.WriteLine(sb.ToString());
    		}
        }
    
    	//Rename the file
    	File.Move(file_name, Path.ChangeExtension(file_name, "dat"));  //with or without a leading period
    }
