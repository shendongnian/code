    in your form2 where datagridview resides do this: 
	public DataGridView DgReport = new DataGridView();
	private void buttonReport_Click()
	{
		//assuming your dataGridview is already populated
		DgReport = yourDataGridview;
		Form3 form3 = new Form3(this);
		form3.ShowDialog();
		form3.Dispose();
	}
	In Form3: 
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
