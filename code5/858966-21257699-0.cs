        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               TextBox tmp = sender as TextBox ;
               if(SpellCheck(tmp.Text))
               {
                        // No Error.
               }
               else
               {
                     // Error 
               }
        }
       // SpellCheck is a function checking the spelling(which you have to make.)  
