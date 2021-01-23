     private void btnInsert_Click(object sender, EventArgs e)
     {
        if (string.IsNullOrWhitespace(txtPosition.Text))
        {
            MessageBox.Show("Please enter a position");
            return; 
        }
        if (string.IsNullOrWhitespace(txtActorName.Text))
        {
            MessageBox.Show("Please enter an Actor Name");
            return;
        }
        int Position;
        if (!int.TryParse(txtPosition.Text, out Position))
        {
            MessageBox.Show("Please enter a number in the position field");
            return;
        }
        InsertIntoArrayList(txtActorName.Text, Position);
        PopulateActors();
    }
