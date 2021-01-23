    private void buttons_Click(object sender, EventArgs e)
        {
            //Update Tag value
            if (((Button)sender).Tag == null || (bool)((Button)sender).Tag == false)
                ((Button)sender).Tag = true;
            //Check state of all buttons
            foreach (Button btn in buttons)
            {   
                //One of the buttons wasn't clicked
                if ((bool)btn.Tag == false)if (((Button)sender).Tag == null || (bool)((Button)sender).Tag == false)
                    return;
            }
            //All buttons were clicked
            button4.Enabled = true;
        }
