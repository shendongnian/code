    protected void Page_Init(object sender, EventArgs e)
    {
        // CREATE/ADD YOUR CONTROLS HERE
        Table table = new Table();
        table.ID = "table1";
        for (int i = 0; i < ClickCount; i++)
        {
            TableRow row1 = new TableRow();
            TableRow row2 = new TableRow();
            TableRow row3 = new TableRow();
            TableRow row4 = new TableRow();
            TableRow row5 = new TableRow();
            TableRow row6 = new TableRow();
            TableRow row7 = new TableRow();
            TextBox TxtBoxF = new TextBox();
            TextBox TxtBoxL = new TextBox();
            TextBox TxtBoxA = new TextBox();
            DropDownList ddlPCountry = new DropDownList();
            DropDownList ddlPCommittee = new DropDownList();
            Label lblF = new Label();
            Label lblL = new Label();
            Label lblA = new Label();
            Label lblPCountry = new Label();
            Label lblPCommittee = new Label();
            // Add the runat=server atributes here....
            TxtBoxF.Attributes.Add("runat", "server");
            TxtBoxL.Attributes.Add("runat", "server");
            TxtBoxA.Attributes.Add("runat", "server");
            ddlPCountry.Attributes.Add("runat", "server");
            ddlPCommittee.Attributes.Add("runat", "server");
            lblF.Attributes.Add("runat", "server");
            lblL.Attributes.Add("runat", "server");
            lblA.Attributes.Add("runat", "server");
            lblPCountry.Attributes.Add("runat", "server");
            lblPCommittee.Attributes.Add("runat", "server");
            TxtBoxF.ID = "TextBoxF" + i.ToString();
            TxtBoxL.ID = "TextBoxL" + i.ToString();
            TxtBoxA.ID = "TextBoxA" + i.ToString();
            ddlPCountry.ID = "ddlPCountry" + i.ToString();
            ddlPCommittee.ID = "ddlPCommittee" + i.ToString();
            lblF.ID = "LabelF" + i.ToString();
            lblL.ID = "LabelU" + i.ToString();
            lblA.ID = "LabelA" + i.ToString();
            lblPCountry.ID = "LabelPCountry" + i.ToString();
            lblPCommittee.ID = "LabelPCommittee" + i.ToString();
            lblF.Text = "First Name: ";
            lblL.Text = "Last Name :";
            lblA.Text = "Age: ";
            lblPCountry.Text = "Preferred Country: ";
            lblPCommittee.Text = "Preferred Committee: ";
            ddlPCountry.DataSource = countryDt;
            ddlPCountry.DataValueField = "CountryID";
            ddlPCountry.DataTextField = "CountryName";
            ddlPCountry.DataBind();
            ddlPCommittee.DataSource = committeeDt;
            ddlPCommittee.DataValueField = "CommitteeID";
            ddlPCommittee.DataTextField = "CommitteeName";
            ddlPCommittee.DataBind();
            for (int a = 0; a < 2; a++)
            {
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(lblF);
                cell2.Controls.Add(TxtBoxF);
                row1.Controls.Add(cell1);
                row1.Controls.Add(cell2);
            }
            for (int b = 0; b < 2; b++)
            {
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(lblL);
                cell2.Controls.Add(TxtBoxL);
                row2.Controls.Add(cell1);
                row2.Controls.Add(cell2);
            }
            for (int c = 0; c < 2; c++)
            {
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(lblA);
                cell2.Controls.Add(TxtBoxA);
                row3.Controls.Add(cell1);
                row3.Controls.Add(cell2);
            }
            for (int d = 0; d < 2; d++)
            {
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(lblPCountry);
                cell2.Controls.Add(ddlPCountry);
                row4.Controls.Add(cell1);
                row4.Controls.Add(cell2);
            }
            for (int f = 0; f < 2; f++)
            {
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(lblPCommittee);
                cell2.Controls.Add(ddlPCommittee);
                row5.Controls.Add(cell1);
                row5.Controls.Add(cell2);
            }
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            table.Rows.Add(row4);
            table.Rows.Add(row5);
        }
        Panel1.Controls.Add(table);
        Panel1.Controls.Add(new LiteralControl("<br />"));
        Panel1.Controls.Add(new LiteralControl("<br />"));
        conn.Close();
    }  
