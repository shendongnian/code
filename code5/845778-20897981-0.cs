    ScrollViewer scrollViewer;
     private static void OnListVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
                {
                    //Create an object of the same class(page).      
                    MyPage page = obj as MyPage ;
                    ScrollViewer viewer = page.scrollViewer;
        
                    //Checks if the Scroll has reached the last item based on the ScrollableHeight
                    bool atBottom = viewer.VerticalOffset >= viewer.ScrollableHeight;
        
                    if (atBottom)
                    {
                        //Type your Code here after checking the vertical scroll.               
                    }
                }
