    string clickedButtonId;
    private void createPagingButtons(DateTime firstDayofWeek, DateTime lastDayofWeek)
    {
        int i = 1;
        SqlDataReader returnedQuery = getDefaultUser(firstDayofWeek, lastDayofWeek);
        while (returnedQuery.Read())
        {
            string buttonName = returnedQuery["Person"].ToString();
            Button btn = new Button();
            btn.ID = buttonName;
            btn.Click += new EventHandler(btn_Click);              
            //...
            pagingPanel.Controls.Add(btn);
            if (btn.ID==this.clickedButtonId) btn.Focus();
            i++;
        }
    }
    private void btn_Click(object s, EventArgs e)
    {
       this.clickedButtonId = ((Button) s).ID;
    }
