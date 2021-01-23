	private Form2 _form2 {get;set;}
	public Form3(Form2 form2)
	{
		_form2 = form2;
	}
	private buttonGenerateReport_Click()
	{
		int columnsCount;
		var writer = new StreamWriter("test.csv");
		//get number of columns
		columnsCount = _form2.DgReport.Columns.Count;
		for (int i = 0; i < columnsCount - 1; i++)
		{ 
		    writer.Write(_form2.DgReport.Columns[i].Name.ToString().ToUpper() + ",");
		} 
		writer.WriteLine();
		//write on excel
		for (int i = 0; i < (_form2.DgReport.Rows.Count - 1); i++)
		{ 
		    for (int j = 0; j < columnsCount; j++)
		    { 
		        if (_form2.DgReport.Rows[i].Cells[j].Value != null)
		        {
		            writer.Write(_form2.DgReport.Rows[i].Cells[j].Value + ",");
		        }
		        else 
		        {
		            writer.Write(",");
		        }
		    }
		    writer.WriteLine();
		}
		//close file
		writer.Close();
	}
