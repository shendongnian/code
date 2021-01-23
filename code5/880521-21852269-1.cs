    private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
    {
        var uiElement = sender as UIElement;
        uiElement.MouseLeave -= UIElement_OnMouseLeave;
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000); // or 500ms
            Dispatcher.Invoke(() =>
            {
                if (!uiElement.IsMouseOver)
                {
                    // Animation Code Goes Here;
                }
                uiElement.MouseLeave += UIElement_OnMouseLeave;
            });
        });
    }
