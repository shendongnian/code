    private bool NeedToBeChanged = true;
    private void RunButton_Click(object sender, EventArgs e)
        {
            NeedToBeChanged =false;
            resetControlColor(); //this function sets the text color to Black
            NeedToBeChanged =true;
        }
    private void AHReg_TextChanged(object sender, EventArgs e)
        {
                if(NeedToBeChanged)
                AHReg.ForeColor = Color.Red;
        }
