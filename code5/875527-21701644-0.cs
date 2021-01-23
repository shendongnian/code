     private void TextBoxNote_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ApplicationBarIconButton button= (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (TextBoxNote.Text == "")
            {
                button.IsEnabled = false;
            }
            else
            {
                button.IsEnabled = true;
            }
        }
