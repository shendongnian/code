    private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            string chbxName = ((CheckBox)sender).Name;
            //Necessary code for identifying the CheckBox and following processes ...
            checkBox = Code which will determine what checkBox sent it.
            if (checkBox.Checked)
            { Box.ChangeState(checkBox, true); }
            else { Box.ChangeState(checkBox, false);}
        }
