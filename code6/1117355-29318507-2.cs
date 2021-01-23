    private void ActiveInactiveImage_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
            {
    
                Image imgobj = sender as Image;
                GroupClass gcobj = (GroupClass)imgobj.DataContext;
                if (gcobj != null)
                {
                    gcobj.IsActive = !gcobj.IsActive;    
                }
            }
