    public static void ScrollAndClick(HtmlControl Control)
        {
            bool isClickable = false;
            if (Control.TryFind())
            {
                while (!isClickable)
                {
                    try
                    {
                        Control.EnsureClickable();
                        Mouse.Click(Control);
                        isClickable = true;
                    }
                    catch (FailedToPerformActionOnHiddenControlException)
                    {
                        Mouse.MoveScrollWheel(-1);
                        throw;
                    }
                }
            }
            else
            {
                throw new AssertInconclusiveException("Control Not Found");
            }
 
        }
