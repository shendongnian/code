    private void Button_Click_1(object sender, System.Windows.Input.GestureEventArgs e)        
    {
        PhoneNumberResult obj;
        obj.DisplayName = "testing name";
        obj.PhoneNumber = num.Text;
        PhoneCallTask call = new PhoneCallTask();
        call.DisplayName = obj.DisplayName;
        call.PhoneNumber = obj.PhoneNumber;
        call.Show();
    }      
