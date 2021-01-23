    private void AddTapGesture()
    		{
                //  you can achieve this from user interface look image below
                YourImageView.UserInteractionEnabled = true;
                var tapGesture = new UITapGestureRecognizer(this,  new ObjCRuntime.Selector("ImageTrigger:"))
                {
                    NumberOfTapsRequired = 1 // change number as you want 
                };
                YourImageView.AddGestureRecognizer(tapGesture);
    		}
    		[Export("ImageTrigger:")]
    		 public void ImageTrigger(UIGestureRecognizer sender)
    		{
                
    			System.Diagnostics.Debug.WriteLine("Button Clicked");
    		}
