    UIAlertView alert = new UIAlertView();
    alert.Title = "Title";
    alert.AddButton("OK");
    alert.Message = "Please Enter a Value.";
    alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
    alert.Clicked += (object s, UIButtonEventArgs ev) => {
      // handle click event here
      // user input will be in alert.GetTextField(0).Text;
    };
    alert.Show();
