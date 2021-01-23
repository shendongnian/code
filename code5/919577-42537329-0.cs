            private void txt_in1_TextChanged(object sender, TextChangedEventArgs e)
        {
           int i = txt_in1.SelectionStart;
           if (bsp1 != 1)
           {
               if (i == 2)
               {
                   txt_in1.Text += ":";
                   txt_in1.SelectionStart = i + 1;
               }
           }
        }
        private void txt_in1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                bsp1 = 1;
            }
            else
            {
                bsp1 = 0;
            }
        }
