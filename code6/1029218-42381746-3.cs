        public static RichTextBox FindRichTextBox(DependencyObject obj, string name)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                //                                            add the name condition
                if (child != null && child is RichTextBox && ((RichTextBox)child).Name == name)
                    return (RichTextBox)child;
                else
                {
                    RichTextBox childOfChild = FindRichTextBox(child, name);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
