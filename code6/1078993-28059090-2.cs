            private void Inputnr1box_KeyPress(object sender, KeyPressEventArgs e)
            {        
                if (char.IsControl(e.KeyChar) || !char.IsDigit(e.KeyChar) )
                {
                    e.Handled = true; // Not a DIGIT
                }
                else
                {                 
                    // Else test for existence
                    int number;
                    if( Int32.TryParse(e.KeyChar.ToString(), out number) )
                    { 
                       if(row.Contains(number))
                       {
                         e.Handled = true;  // Already exists
                       }
                       else
                       {
                        row.Apeend(number); // New number
                       }
                    }
                } 
            }
