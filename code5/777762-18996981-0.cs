    //This button needs to give the error if the name or position in the array are left blank//
    private void btnInsert_Click(object sender, EventArgs e)
    {
        // BIG PROBLEM HERE!!!!
        do
        {
            string message = "Invalid Name or Position entered.";
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        while (int.Parse(txtPosition.Text == null));
    
        InsertIntoArrayList(actName, posNum);
        PopulateActors();
    }
