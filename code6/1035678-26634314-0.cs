    void buttonSave_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOfEmpty(txtNote))
        {
            errorProvider1.SetError(txtNote, "Omg, can't haz empty note");
            return;
        }
        if(string.IsNullOfEmpty(someOtherTextBox))
        {
            errorProvider1.SetError(someOtherTextBox, "Omg, no empty plx!");
            return;
        }
        // 
        ...
    }
