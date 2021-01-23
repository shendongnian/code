    Button b = new Button(); // Create new button
    b.ID = "BT1"; // Set button id "BT1"
    b.Attributes.Add("runat", "server"); // <-------------- Here
    b.Text = "Click"; // Set on button text
    form1.Controls.Add(b); // add this button to form1
