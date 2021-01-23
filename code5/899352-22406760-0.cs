       var lstTextValues = new  SortedList<string, string>();
        lstTextValues.Add(this.txbGroupSeparator.Name,this.txbGroupSeparator.Text);
        lstTextValues.Add(this.txbDecimalSeparator.Name,this.txbDecimalSeparator.Text);
        lstTextValues.Add(this.txbCellDelimiter.Name,this.txbCellDelimiter.Text);
        
        this.okButton.Enabled = true;
        if(lstTextValues.Exists(e => string.IsNullOrEmpty(e.Value)))
        {
            this.okButton.Enabled = false;
        
        }
        foreach (KeyValuePair<string, int> srtlst in lstTextValues)
        {
            if (lstTextValues.Count(e => e.Value == srtlst.Value) > 1)
            { 
                 this.okButton.Enabled = false;
            }
         }
