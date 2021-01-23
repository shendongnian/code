            <ItemsControl Margin="10" ItemsSource="{Binding YoursItemsObserableCollection}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <local:StaggeredPanel />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <DataTemplate.Resources>
                        <Style TargetType="TextBlock">
                            <Setter Property="FontSize" Value="18"/>
                            <Setter Property="HorizontalAlignment" Value="Center"/>
                        </Style>
                    </DataTemplate.Resources>
                    <Grid>
                        <Ellipse Fill="Silver" Width="40" Height="40"/>
                        <StackPanel>
                            <TextBlock Margin="3,3,3,0" Text="{Binding Path=Name}"/>
                        </StackPanel>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>   
    class StaggeredPanel : Panel
    {
        protected override Size MeasureOverride (Size availableSize)
        {
            foreach (var childo in InternalChildren)
            {
                FrameworkElement child = childo as FrameworkElement;
                if (child != null)
                {
                    var childMaxSize = new Size (double.PositiveInfinity, availableSize.Height);
                    child.Measure (childMaxSize);
                }
            }
            return availableSize;
        }
        protected override Size ArrangeOverride (Size finalSize)
        {
            double x = 0;
            double y = 0;
            bool shift = true;
            double shiftOffset;
            if (InternalChildren.Count > 0)
            {
                FrameworkElement offsetChild = InternalChildren[0] as FrameworkElement;
                shiftOffset = offsetChild.DesiredSize.Height / 2;
                for (int i = 0; i < InternalChildren.Count; i++)
                {
                    FrameworkElement child = InternalChildren[i] as FrameworkElement;
                    if (child != null)
                    {
                        double finalY = y;
                        if (shift)
                        {
                            finalY += shiftOffset;
                        }
                        shift = !shift;
                        child.Arrange (new Rect (new Point (x, finalY), child.DesiredSize));
                        x += child.DesiredSize.Width;
                        double nextWidth = 0;
                        if (i + 1 < InternalChildren.Count)
                        {
                            FrameworkElement nextChild = InternalChildren[i + 1] as FrameworkElement;
                            nextWidth = child.DesiredSize.Width;
                        }
                        if (x + nextWidth > finalSize.Width)
                        {
                            shift = true;
                            x = 0;
                            y += child.DesiredSize.Height;
                        }
                    }
                }
            }
            return finalSize; // Returns the final Arranged size
        }
    }
