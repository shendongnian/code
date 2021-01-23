    private async Task GetDataAsync()
    {
            //if (this._table.Count != 0) return;
       try
       {
            this.Table.Clear();
            var jsonObject = await DownloadSpreadsheet.GetJson();
            for (int row = 0; row < jsonObject["rows"].Count(); row++)
            {
    
                Table table = new Table();
    
                table.Day = jsonObject["rows"][row]["c"][0]["v"].ToString();
    
                table.Month = jsonObject["rows"][row]["c"][5]["v"].ToString();
                table.Year = jsonObject["rows"][row]["c"][6]["v"].ToString();
                table.People = jsonObject["rows"][row]["c"][7]["v"].ToString();
    
    
                this.Table.Add(table);
            }
          }
       catch(Exception ex)
         { this.Error = ex; }
    }
