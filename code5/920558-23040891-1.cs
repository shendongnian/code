    private void Button_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!(e.OriginalSource is TextBlock))
        {
            MessageBox.Show("You click on the button");
        }
        else
        {
            switch ((e.OriginalSource as TextBlock).Text)
            {
                case "First":
                    MessageBox.Show("You click on first");
                    break;
                case "Second":
                    MessageBox.Show("You click on second");
                    break;
                case "Third":
                    MessageBox.Show("You click on third");
                    break;
            }
        }
    }
