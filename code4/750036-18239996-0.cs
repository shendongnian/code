    Button btnView = new Button();
    btnView.ID = CarID;
    //here
    btnView.Attributes.Add("GCarID", CarID);
    btnView.Text = "View Car";
    btnView.ForeColor = System.Drawing.Color.DeepSkyBlue;
    btnView.BackColor = System.Drawing.Color.Gray;
    btnView.BorderColor = System.Drawing.Color.Violet;
    btnView.Style["top"] = "110px";
    btnView.Style["left"] = "800px";
    btnView.Style["Height"] = "20px";
    btnView.Style["position"] = "absolute";
    btnView.BorderStyle = BorderStyle.Outset;
    btnView.Click += new EventHandler(this.btnView_Click);
    //click
    void btnView_Click(object sender, EventArgs e)
    {
    	Session["CarID"] = ((Button)sender).Attributes["GCarID"];
    	Response.Redirect("View.aspx");
    }
