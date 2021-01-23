            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(contentControl); i++)
            {
                var child = VisualTreeHelper.GetChild(contentControl, i);
                if(child is ContentPresenter)
                {
                    var contentPresenter = child as ContentPresenter;
                    for (int j = 0; j < VisualTreeHelper.GetChildrenCount(contentPresenter); j++)
                    {
                        var innerChild = VisualTreeHelper.GetChild(contentPresenter, j);
                    }
                    break;
                }
            }
