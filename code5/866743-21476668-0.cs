    // Build the dialog.
    var builder = new AlertDialog.Builder(this);
    builder.SetTitle("Click me!");
    
    // Create empty event handlers, we will override them manually instead of letting the builder handling the clicks.
    builder.SetPositiveButton("Yes", (EventHandler<DialogClickEventArgs>)null);
    builder.SetNegativeButton("No", (EventHandler<DialogClickEventArgs>)null);
    var dialog = builder.Create();
    
    // Show the dialog. This is important to do before accessing the buttons.
    dialog.Show();
    
    // Get the buttons.
    var yesBtn = dialog.GetButton((int)DialogInterface.ButtonPositive);
    var noBtn = dialog.GetButton((int)DialogInterface.ButtonNegative);
    
    // Assign our handlers.
    yesBtn.Click += (sender, args) =>
    {
    	// Don't dismiss dialog.
    	Console.WriteLine("I am here to stay!");
    };
    noBtn.Click += (sender, args) =>
    {
    	// Dismiss dialog.
    	Console.WriteLine("I will dismiss now!");
    	dialog.Dismiss();
    };
