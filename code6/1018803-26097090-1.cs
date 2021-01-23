    class MyPanel:Panel
    {
        private bool myRightToLeftLayout=false;
        public bool MyRightToLeftLayout
        {
            get { return myRightToLeftLayout; }
            set 
            {
                if (value != myRightToLeftLayout)
                {
                    foreach (Control item in base.Controls)
                    {
                        try
                        {
                            item.RightToLeft = value==true?RightToLeft.No:RightToLeft.Yes;
                            item.Location = new System.Drawing.Point(base.Size.Width - item.Size.Width - item.Location.X, item.Location.Y);
                        }
                        catch { }
                    }
                    myRightToLeftLayout = value;
                }
            }
        }
    }
