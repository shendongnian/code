          private void Button_Click(object sender, RoutedEventArgs e)
          {
                name = textbox_Name.Text;
                age = textbox_age.Text;
                gender = textbox_gender.Text;
                if (gender != "World" || name != "World" || age!="World" )
                {
                    MessageBox.Show("Invalid Entry.");
                }         
           }
