        private void Map_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = FindChildOfType<Grid>(MyMap);
            grid.ManipulationCompleted += Map_ManipulationCompleted;
            grid.ManipulationDelta += Map_ManipulationDelta;
        }
        private void Map_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // disable zoom
            if (e.DeltaManipulation.Scale.X != 0.0 ||
                e.DeltaManipulation.Scale.Y != 0.0)
                e.Handled = true;
            //disable moving
            if (e.DeltaManipulation.Translation.X != 0.0 ||
                e.DeltaManipulation.Translation.Y != 0.0)
                e.Handled = true;
        }
        private void Map_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            // disable zoom
            if (e.FinalVelocities.ExpansionVelocity.X != 0.0 ||
                e.FinalVelocities.ExpansionVelocity.Y != 0.0)
                e.Handled = true;
            //disable moving
            if (e.FinalVelocities.LinearVelocity.X != 0.0 ||
                e.FinalVelocities.LinearVelocity.Y != 0.0)
            {
                e.Handled = true;
            }
        }
        public static T FindChildOfType<T>(DependencyObject root) where T : class
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                DependencyObject current = queue.Dequeue();
                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }
        private void MyMap_Tap(object sender, GestureEventArgs e)
        {
            //This is still working
        }
