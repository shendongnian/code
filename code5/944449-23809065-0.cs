    foreach (cUserControl c in cElements)
    {
                int[][] pointData = new int[][] 
                { 
                    new int[] { _control.Location.Y, _control.Location.Y + _control.Size.Height }, 
                    new int[] { _control.Location.X, _control.Location.X + _control.Size.Width } 
                };
                foreach (Control sControl in cElements)
                {
                    if (sControl == _control) continue;
                    if (sControl.Location.Y >= pointData[0][0] && sControl.Location.Y <= pointData[0][1])
                    {
                        if (sControl.Location.X >= pointData[1][0] && sControl.Location.X <= pointData[1][1])
                        {
                            // Match
                        }
                    }
                }
    }
