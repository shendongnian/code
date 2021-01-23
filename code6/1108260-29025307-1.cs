    Thread t  = new Thread(StartProc);
    t.Start();
    public void StartProc()
    {
      using (var input = new SLDocument(filePath))
      {
        SLWorksheetStatistics stats = input.GetWorksheetStatistics();
	    
        int iStartColumnIndex = stats.StartColumnIndex;
        for (row = stats.StartRowIndex + 1; row <= stats.EndRowIndex; ++row)
        {
	        int percent = (row+1)*100/stats.EndRowIndex;
            //Here is the label
            setStatus("Reading row " + row + " of " + stats.EndRowIndex);
            var dataRowTmp = new DataRow()
            {
                name = input.GetCellValueAsString(row, iStartColumnIndex),
                sku = input.GetCellValueAsString(row, iStartColumnIndex + 1),
                value2 = input.GetCellValueAsString(row, iStartColumnIndex + 2),
                value3 = input.GetCellValueAsString(row, iStartColumnIndex + 3)
            };
            setProgress(percent);
            
            UpdateTable(dataRowTmp);
        }
        setStatus("");
        setProgress(0);
      }
	}
	private void SetStatus(string value)
	{
      if (this.InvokeRequired)
      {
        SetStatusDelg dlg = new SetStatusDelg(this.SetStatus);
        this.Invoke(value);
		return;
      }
      lblStatus.Text = value;
	}
	private void SetProgress(int value)
	{
      if (this.InvokeRequired)
      {
        SetProgressDelg dlg = new SetProgressDelg(this.SetStatus);
        this.Invoke(value);
		return;
      }
      progressBar1.value = value;
	}
    private void UpdateTable(string value)
	{
      if (this.InvokeRequired)
      {
        UpdateTableDelg dlg = new UpdateTableDelg(this.UpdateTable);
        this.Invoke(value);
		return;
      }
      myTable.Add(value);
	}
