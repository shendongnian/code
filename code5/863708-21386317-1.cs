     private void plusButton_click(object sender, EventArgs e)
        {
            var currentButton = sender as Button;
            var name = currentButton.Name;
    
            switch (name)
            {
                // Ultimate
                case "plus0_0":
                                         
                    (currentButton.Tag as Label).Text = "test";
                    break;
                case "plus0_1":
                    (currentButton.Tag as Label).Text ="test2"
                    break;
            }
        }
