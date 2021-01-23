        public void cboSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {           
            // Try to access it from here
            switch ((ComboBox)sender.SelectedIndex)
            {
                case 1:  //ODBC - Handle this selection
                    break;
                case 2:  //CSV - Handle this selection
                    break;
            }
        }
