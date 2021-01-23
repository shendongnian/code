    TextBox[] boxes = new[] { txtFirstName, txtLastName, txtPayRate,
                              txtStartDate, txtEndDate };
    IEnumerable<TextBox> unfilledBoxes = boxes.Where(b => b.Text == "");
    foreach (TextBox box in unfilledBoxes)
    {
        box.BackColor = System.Drawing.Color.Yellow;
    }
    
    if (!unfilledBoxes.Any())
    {
        Session["txtFirstName"] = txtFirstName.Text;
        Session["txtLastName"] = txtLastName.Text;
        Session["txtPayRate"] = txtPayRate.Text;
        Session["txtStartDate"] = txtStartDate.Text;
        Session["txtEndDate"] = txtEndDate.Text;
        Response.Redirect("frmPersonnelVerified.aspx");
    }
