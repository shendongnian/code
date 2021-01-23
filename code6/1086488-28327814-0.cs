    class DynamicGrid : Grid
    {
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            UIElementCollection elements = base.InternalChildren;
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].SetValue(Grid.RowProperty, correctRow);
            }
            return base.ArrangeOverride(arrangeSize);
        }
    }
