        void bigButton_MouseLeave(object sender, EventArgs e)
        {
            if(submenu && !isMouseInControl(sender as Control))
            {
                submenu = false;
                // Disable submenu here
            }
        }
        void bigButton_MouseEnter(object sender, EventArgs e)
        {
            if(submenu || isMouseInControl(sender as Control))
            {
                submenu = true;
                // Enable submenu here
            }
        }
