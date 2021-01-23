    private void btSave_Click(object sender, EventArgs e)
    {
        db.CompleteTransaction();
        db.BeginTransaction(); // everything user edit after this will be saved automatically because we don't have Transaction anymore so we Begin it again
    }
