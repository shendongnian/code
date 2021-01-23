    // Take the screenshot
    UIGraphics.BeginImageContext(View.Frame.Size);
    View.DrawViewHierarchy(View.Frame, true);
    UIImage image = UIGraphics.GetImageFromCurrentImageContext();
    UIGraphics.EndImageContext();
    // Don't save it to the album (unless you need to)
    // Create an email
    var _mailController = new MFMailComposeViewController();
    _mailController.SetToRecipients(new []{"john@doe.com"});
    _mailController.SetSubject("Send Screenshot");
    _mailController.SetMessageBody("This is a screenshot of the app!", false);
    // Add the screenshot as an attachment
    _mailController.AddAttachmentData(image.AsPNG(),"image/png","Screenshot.png");
    // Handle the action to take when the user completes sending the email
    _mailController.Finished += ( object s, MFComposeResultEventArgs args) => {
        System.Console.WriteLine (args.Result.ToString ());
        args.Controller.DismissViewController (true, null);
    };
    // Show the email view
    PresentViewController (_mailController, true, null);
