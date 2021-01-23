        int noofquestions = 100;
        int k = 1;
        for (int i = 1; i <= noofquestions / 5; i++)
        {
            HtmlTableRow tRow = new HtmlTableRow();
            //TableRow tRow = new TableRow();          
            myTable.Rows.Add(tRow);
            for (int j = 1; j <= 5; j++)
            {
                HtmlTableCell tCell = new HtmlTableCell();            
                tRow.Cells.Add(tCell);
                Button link = new Button();
                //LinkButton link = new LinkButton();
                link.ID = "link" + k;
                link.Text = k.ToString();
                tCell.Controls.Add(link);
                ViewState[link.ID] = k;
                link.Click += new EventHandler(link_Click);
                tCell.Controls.Add(link);
                //link.Click += new EventHandler(this.btn_click);
                k = k + 1;
            }
        }
        void link_Click(object sender, EventArgs e)
    {
            Button b = (sender)Button;
            string value = ViewState[b.ID].ToString();
    }
