    private void phonenumber_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask call = new PhoneCallTask();
            call.PhoneNumber = ((TextBlock)sender).Text;
            call.Show();
         }
