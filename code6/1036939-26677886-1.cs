    public int indexx = -1;
    private void StackPanel_Click(object sender, RoutedEventArgs e)
    {
       
        if (indexx == 1)
        { 
            indexx = -1;
            Canvas.SetZIndex(panel, indexx);
            
        }
        else
        {
            indexx = 1;
            Canvas.SetZIndex(panel, indexx);
        }
                    
    }
