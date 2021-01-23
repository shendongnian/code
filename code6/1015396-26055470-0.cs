            bool iscontrolexist= uIwaitingButton.WaitForControlEnabled();
            while (!iscontrolexist)
            {
                try
                {
                 uIwaitingButton.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                 uIwaitingButton.SetFocus(); // setting focus for the on button
                 iscontrolexist= uIwaitingButton.WaitForControlExist(100);
                }
                catch (Exception ex)
                {
                   // possibly exception for setfocus() method call 
                   // handle exception, to write a log message                   
                }
            }
            // perform the button click after find the control
            // Click 'Save' button
            Mouse.Click(uIwaitingButton, new Point(100,100));
