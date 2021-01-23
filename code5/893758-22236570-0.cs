    int i = 1;
    
    while (sqlReader.Read())
    {
        //Create label
        var button = new Button {Text = String.Format(sqlReader.GetString("productName"), i)};
        //Position label on screen
        button.Left = 110;
        button.Top = (i + 1)*30;
    
        // Get product data
        var prodData1 = sqlReader["prodData1"];
        var prodData2 = sqlReader["prodData2"];
        // etc.
        
        button.Click += (sender,e)=>{
            // In here, you can access prodData1 and prodData2
        };
        //Add controls to form
        Controls.Add(button);
        i++;
    }
