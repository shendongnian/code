    private bool isParsable(TextBox t) //takes a TextBox as paramater and returns true if
        {                              // its parsable
            int i = 4;
            if (int.TryParse(t.Text, out i) == true)
                return true;
            else
                return false;            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(isParsable(tbox1) == true && isParsable(tbox2) == true) //if every textbox
            {                                                          //is parsable print
                tblock1.Text = "succes";
            }
            else
            {
                tblock1.Text = "error";
            }
        }
