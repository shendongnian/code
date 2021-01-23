    var dataSet = new DataSet();
    dataSet.ReadXml(@"D:\temp\my.xml");
    
    var defaultView = new DataView(dataSet.Tables[0]);
    
    /*
    	Operator LIKE is used to include only values that match a pattern with wildcards. 
    	Wildcard character is * or %, it can be at the beginning of a pattern '*value', at the end 'value*', or at both '*value*'. 
    	Wildcard in the middle of a patern 'va*lue' is not allowed.
    */
    Func<string, string> escapeLike = valueWithoutWildcards => {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < valueWithoutWildcards.Length; i++)
      {
        char c = valueWithoutWildcards[i];
        if (c == '*' || c == '%' || c == '[' || c == ']')
          sb.Append("[").Append(c).Append("]");
        else if (c == '\'')
          sb.Append("''");
        else
          sb.Append(c);
      }
      
      return sb.ToString();
    };
    
    
    var w = new Window();
    w.Loaded += (o,e) => {
    
    	var stackPanel = new StackPanel();
    	var myButton = new Button();
    	myButton.Content = "Click me!";
    	myButton.Click += delegate { 
    
    		var userQueryString = "screw";
    
    		// todo; you might want to escape dataColumn.ColumnName, but not sure
    		var finalQueryList = new List<string>();
    		foreach(DataColumn dataColumn in defaultView.Table.Columns)
    			finalQueryList.Add(string.Format("{0} LIKE '%{1}%'", 
                     dataColumn.ColumnName, escapeLike(userQueryString)));
    		
    		defaultView.RowFilter = string.Join(" OR ", finalQueryList); 
    	};
    	
    	stackPanel.Children.Add(new DataGrid() { ItemsSource = defaultView });
    	stackPanel.Children.Add(myButton);
    	
        w.Content = stackPanel;
    };
    
    
    w.Show();
    
    new Application().Run(w);
