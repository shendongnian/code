    private void GenerateControls()
    {
        int i = 0;
        foreach (List<DataRow> lst in grids)
        {
            dt = lst.CopyToDataTable();
            GridView grv = new GridView();
            grv.AlternatingRowStyle.BackColor = System.Drawing.Color.FromName("#cccccc");
            grv.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            grv.ID = "grid_view" + i;
            //grv.Visible = false;//Commented as the grid needs be generated on client side, in order to make it visible from JavaScript/jQuery
            grv.Attributes.Add("style", "display:none;");
            grv.DataSource = dt;
            grv.DataBind();
            //Adding dynamic link button
            LinkButton lnkButton = new LinkButton();
            lnkButton.Text = "button " + i;
            //lnkButton.Click += new EventHandler(lnkButton_Click);
            lnkButton.ID = "lnkButton" + i;
            lnkButton.OnClientClick = "ShowGrid(" + grv.ClientID + ");";
            Label lblTipo = new Label();
            lblTipo.Text = "text " + i;
            lblTipo.ID = "lbl" + i;
            tempPanel.Controls.Add(lblTipo);
            tempPanel.Controls.Add(grv);
            tempPanel.Controls.Add(lnkButton);
            tempPanel.DataBind();
            i++;
        }
    }
