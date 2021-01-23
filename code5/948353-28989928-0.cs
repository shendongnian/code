    private void LayoutStackPanel(IEnumerable<UIElement> elements)
    {
        stackPanel.Children.Clear();
        if (elements.Count == 0)
        {
            stackPanel.Height = 0;
        }
        else
        {
            // height must be removed or ui elements will overlap
            stackPanel.ClearValue(StackPanel.HeightProperty);
            foreach (var element in elements)
            {
                stackPanel.Children.Add(element);
            }
        }
    }
