     private int ConvertMousePointToScreenIndex(Point mousePoint)
        {
            //first get all the screens 
            System.Drawing.Rectangle ret;
            for (int i = 1; i <= Screen.AllScreens.Count(); i++)
            {
                ret = Screen.AllScreens[i - 1].Bounds;
                if (ret.Contains(mousePoint))
                    return i - 1;
            }
            return 0;
        }
