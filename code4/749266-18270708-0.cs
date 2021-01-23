    private class CustomWebView : UIWebView      
    {             
        public override UIView InputAccessoryView     
        {                 
            get                   
            {                     
                return null;                 
            }             
        }         
    }      
    public override void ViewDidLoad()  
    {             
        base.ViewDidLoad(); 
        // Perform any additional setup after loading the view, typically from a nib.                     RectangleF frame = new RectangleF(0, 0, 200, 30);                          
        UITextField txfTest = new UITextField();             
        txfTest.Frame = frame;             
        txfTest.BorderStyle = UITextBorderStyle.RoundedRect;             
        txfTest.Placeholder = "Click here";             
        txfTest.EditingDidBegin += (object sender, EventArgs e) => {                     
            // do something             
        };
        CustomWebView webView = new CustomWebView();             
        webView.LoadRequest(new NSUrlRequest(new NSUrl(@"http://google.com")));             
        webView.Frame = new RectangleF(0, 100, 320, 480);                          
        webView.AddSubview(txfTest);                         
        
        this.View.AddSubview(webView);         
    }
