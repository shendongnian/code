    private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
                Run r = e.OriginalSource as Run;
                if(r != null)
                {
                    Hyperlink hyperlink = r.Parent as Hyperlink;
                    if(hyperlink != null)
                    {
                        //Your code here
                    }
                }
            }
        }
