    void buttonSave_Clicked(object sender, EventArgs e)
    {
        bool isOk = true;
        if(string.IsNullOfEmpty(txtNote))
        {
            errorProvider1.SetError(txtNote, "Omg, can't haz empty note");
            isOk = false;
        }
        if(string.IsNullOfEmpty(someOtherTextBox))
        {
            errorProvider1.SetError(someOtherTextBox, "Omg, no empty plx!");
            isOk = false;
        }
        // 
        if(isOk)
        {
            ...
        }
    }
