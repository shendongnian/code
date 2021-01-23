    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string AdminNumber = Convert.ToString(txtAdmin.Text);
        string Name = Convert.ToString(txtName.Text);
        string BlogStory = Convert.ToString(txtStory.Text);
        string BlogType = cblType.SelectedValue;
        insertGameRecord(AdminNumber, Name, BlogStory, BlogType);
    }
