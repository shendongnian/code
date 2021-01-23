    public void SetPanelChild<T>(Panel panel)
        where T : UIElement, new()
    {
        T element = new T();
        panel.Children.Clear();
        panel.Children.Add(element);
    }
