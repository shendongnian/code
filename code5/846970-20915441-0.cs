     private void button_KeyDown(object sender, KeyEventArgs e)
     {
        ((Control)sender).Controls.Add(helpBox);
        ((Control)sender).Focus(); // Set focus back to control so its KeyUp will be called
     }
     private void button_KeyUp(object sender, KeyEventArgs e)
     {
        ((Control)sender).Controls.Remove(helpBox);
     }
