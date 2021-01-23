        /// <summary>
        /// Create a linear animation
        /// </summary>
        /// <param name="duration"></param>
        public void CreateDoubleLinearAnimation(DependencyObject element, string name, string property, double? valueFrom, double valueTo, TimeSpan timeSpan, Storyboard sb)
        {
            // --- Animation toute bête
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = new Duration(timeSpan);
            animation.To = valueTo;
            if (valueFrom != null)
                animation.From = valueFrom.Value;
            animation.SetValue(Storyboard.TargetNameProperty, name);
            animation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(property));
            sb.Children.Add(animation);
        }
