    void ws_GetIndeksUmumCompleted(object sender, ServiceReference1.GetIndeksUmumCompletedEventArgs e)
    {
    	var result = "";
    	result = e.Result.ToString();
    	if (result.Length > 1)
    	{
    		MessageBox.Show("Data Loaded...");
    		string[] rows1 = result.Split('|');
    		string[] lsMob;
    		for (int i = 0; i < rows1.Length; i++)
    		{
    			lsMob = rows1[i].Split('#');
    			kat.Add(lsMob[1]);
    		}
    	}
    	else
    	{
    		//if no data returned from web service, 
    		//add string "THERE IS NO DATA" to list
    		kat.Add("THERE IS NO DATA");
    	}
    	this.acBox.ItemsSource = kat;
    }
