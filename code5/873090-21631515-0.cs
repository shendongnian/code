     protected void GenerateButton_Click(object sender, EventArgs e)
        {
            if (JobRelPhase_DropDown.SelectedIndex != -1)
            {
                if (JobActive())
                {
                    SetButton(GenerateButton, false);
                    //JobRelPhase_DropDown.SelectedIndex = -1; //to set back to the top of the list
                     JobRelPhase_DropDown.Items.Clear();
                    JobRelPhase_DropDown.DataBind();
    JobRelPhase_DropDown.Items.Insert(0, new ListItem("Text","Value"));
                }
            }
        }
