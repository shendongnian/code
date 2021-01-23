    private void Handler(object sender, MouseButtonEventArgs e)
    {
        // Check actual sender here which can be Canvas, Ellipse or Path.
        Ellipse senderObject = e.OriginalSource as Ellipse;
        if(senderObject == null)
        {
           Path senderPath = e.OriginalSource as Path;
        }
    }
