    private void Polygon_MouseDown(object sender, MouseButtonEventArgs args)
    {
        System.Windows.Forms.MessageBox.Show("Mouse Down!");
        
        Polygon obj = sender as Polygon;
        this.Dispatcher.Invoke(new Action(() =>
        {
             obj.Width += 50;
        });
    }
    
    private void Polygon_MouseUp(object sender, MouseButtonEventArgs args)
    {
        System.Windows.Forms.MessageBox.Show("Mouse Up!");
        
        Polygon obj = sender as Polygon;
        this.Dispatcher.Invoke(new Action(() =>
        {
             obj.Height += 50;
        });
    }
