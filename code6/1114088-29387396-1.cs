     public bool HasTouchInput()
        {
            foreach (TabletDevice tabletDevice in Tablet.TabletDevices)
            {
                //Only detect if it is a touch Screen 
                if(tabletDevice.Type == TabletDeviceType.Touch)
                    return true;
            }
    
            return false;
        }
