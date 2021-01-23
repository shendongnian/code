    private void MouseLeftButtonDownCommand(MouseButtonEventArgs e)
            {
    
                if (e.ClickCount == 1)
                {
                    _dtMouseClick.Start();
                }
    
                else if(e.ClickCount > 1)
                {
                    _dtMouseClick.Stop();
    
                    //the code of the double click
                }
            }
