            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(contentControl); i++)
            {
                var child = VisualTreeHelper.GetChild(contentControl, i);
                if(child is ContentPresenter)
                {
                    var contentPresenter = child as ContentPresenter;
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(contentPresenter); i++)
                    {
                        var innerChild = VisualTreeHelper.GetChild(contentPresenter, i);
                    }
                    break;
                }
            }
