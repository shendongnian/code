    public UIButton img_UploadImage { get; set; }
    
    public ConstructorClass(){
         img_UploadImage = UIButton.FromType(UIButtonType.Custom);
         img_UploadImage.Frame = new RectangleF(100, 100, 60, 50);
         img_UploadImage.setImage(UIImage.FromFile("UploadLocal.png");
    
         //Set up event handler for "Click" event ("TouchUpInside in iOS terminology)
         img_UploadImage.TouchUpInside += (object sender, EventArgs e) => {
              //Do some action.
         };
    }
