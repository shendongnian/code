       private void SetTopImage()
        {
            Image NewTopImage = FindIconPriority(); // Finds what Icon I would like to have in front.
            ControlStack.Children.Remove(NewTopImage);
            ControlStack.Children.Insert(0, NewTopImage);
        }
