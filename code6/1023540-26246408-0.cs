    CMB.Click(object sender, EventArgs e) //click, changedvalue or something else what you want - change it for your neccesity
    {
        txt.Text = ((ComboBoxItem)CMB_COURSE.SelectedItem).Content.ToString();
        //or, i can't test it now, well do it and edit this answer
        txt.Text = CMB_COURSE.SelectedValue.ToString();
        //or:
        DataRowView row = (DataRowView)CMB_COURSE.SelectedItem;
        if (row != null)
        {
             txt.Text = row[0] + " " + row[1];
        }
    }
