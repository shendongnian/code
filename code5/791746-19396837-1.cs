        private Size ContainerSizeForItem(ItemsControl itemsControl, object item, int index, out UIElement container)
        {
            Size containerSize;
            container = index >= 0 ? ((ItemContainerGenerator)Generator).ContainerFromIndex(index) as UIElement : null;
  
            if (container != null)
            {
                containerSize = container.DesiredSize;
            }
            else
            {
                // It's virtualized; grab the height off the item if available.
                object value = itemsControl.ReadItemValue(item, _desiredSizeStorageIndex);
                if (value != null)
                {
                    containerSize = (Size)value;
                }
                else
                {
                    //
                    // No stored container height; simply guess.
                    //
                    containerSize = new Size();
 
  
                    if (Orientation == Orientation.Horizontal)
                    {
                        containerSize.Width = ContainerStackingSizeEstimate(itemsControl, /*isHorizontal = */ true);
                        containerSize.Height = DesiredSize.Height;
                    }
                    else
                    {
                        containerSize.Height = ContainerStackingSizeEstimate(itemsControl, /*isHorizontal = */ false);
                        containerSize.Width = DesiredSize.Width;
                    }
                }
            }
  
            return containerSize;
        }
        private double ContainerStackingSizeEstimate(IProvideStackingSize estimate, bool isHorizontal)
        {
            double stackingSize = 0d;
  
            if (estimate != null)
            {
                stackingSize = estimate.EstimatedContainerSize(isHorizontal);
            }
 
            if (stackingSize <= 0d || DoubleUtil.IsNaN(stackingSize))
            {
                stackingSize = ScrollViewer._scrollLineDelta;
            }
            return stackingSize;
        }
