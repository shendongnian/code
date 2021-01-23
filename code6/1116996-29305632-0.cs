    private void btnclick_Click(object sender, RoutedEventArgs e)
            {
                if (cb1.IsArrangeValid == true)
                    if (cb2.IsArrangeValid == true)
                        txt1.Text = (txt1.Text + "\n" + "Car:" + cb1.Text + "\n" + "state:" + cb2.Text).Trim();
    
            }
