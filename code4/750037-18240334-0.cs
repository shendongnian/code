    Button btnView = new Button();
    btnView.ID = CarID;
    btnView.Text = "View Car";
    btnView.ForeColor = System.Drawing.Color.DeepSkyBlue;
    btnView.BackColor = System.Drawing.Color.Gray;
    btnView.BorderColor = System.Drawing.Color.Violet;
    btnView.Style["top"] = "110px";
    btnView.Style["left"] = "800px";
    btnView.Style["Height"] = "20px";
    btnView.Style["position"] = "absolute";
    btnView.BorderStyle = BorderStyle.Outset;
    btnView.Command += btnView_Command; // Note: Command event is used instead of Click.
    btnView.CommandArgument = CarID; // Note: CarID is stored in CommandArgument.
    Panel1.Controls.Add(btnView);
    
    void btnView_Command(object sender, CommandEventArgs e)
    {
        string carID = e.CommandArgument.ToString();
        Session["CarID"] = carID;
        Response.Redirect("View.aspx");
    }
