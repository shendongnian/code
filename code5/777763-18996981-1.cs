    //This button needs to give the error if the name or position in the array are left blank//
    private void btnInsert_Click(object sender, EventArgs e)
    {
        if (int.Parse(txtPosition.Text == null)) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        } else {
            InsertIntoArrayList(actName, posNum);
            PopulateActors();
        }
    }
