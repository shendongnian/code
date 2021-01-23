    private void btnColour_Click(object sender, EventArgs e)
    {
        ColorDialog clrDialog = new ColorDialog();
        //show the colour dialog and check that user clicked ok
        if (clrDialog.ShowDialog() == DialogResult.OK)
        {
            //save the colour that the user chose
            c = clrDialog.Color;
        }
    }
    Color c = Color.Black;
    
