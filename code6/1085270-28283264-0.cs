     private void Grid_MouseMove_1(object sender, MouseEventArgs e)
        {
            btn.IsEnabled = false;
            if (txt.IsArrangeValid == true)
            {
                btn.IsEnabled = true;
            }
        }
