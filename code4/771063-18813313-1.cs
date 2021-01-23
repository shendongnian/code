     public Button FindButton(DependencyObject parent)
     {
        // Confirm parent and childName are valid. 
        if (parent == null) return null;
    
        Button homeButton = null;
    
        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childrenCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            // If the child is not of the request child type child
            Button button = child as Button;
            if (button == null)
            {
                // recursively drill down the tree
                homeButton = FindButton(child);
    
                // If the child is found, break so we do not overwrite the found child. 
                if (homeButton != null) break;
            }
            else
            {
                // If the child's name is set for search
                if (button.Name == "HomeButton")
                {
                    // if the child's name is of the request name
                    homeButton = button;
                    break;
                }
            }
        }
    
        return homeButton;
    }
