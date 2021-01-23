    protected override Size ArrangeOverride(Size finalSize)
    {
        int currentIndex = 0;
        for (int index = InternalChildren.Count - 1; index >= 0; index--)
        {
            Rect rect = new Rect(finalSize);
            rect.Location = new Point()
            {
                X = finalSize.Width * PercentagePanel.GetLeft(InternalChildren[index]) - finalSize.Width / 2 + (InternalChildren[index].DesiredSize.Width / 2),
                Y = finalSize.Height * PercentagePanel.GetTop(InternalChildren[index]) - finalSize.Height / 2 + (InternalChildren[index].DesiredSize.Height / 2)
            };
                
            InternalChildren[index].Arrange(rect);
            currentIndex++;
        }
        return finalSize;
    }
