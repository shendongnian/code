        public override void ViewDidLoad()
        {
            UIButton button = new UIButton (new RectangleF (5, 5, frame_width, 30));
            button.TouchUpInside += Method;
            UIPickerView pickerView = new UIPickerView (new RectangleF (5, 45, frame_width, 180));
            pickerView.Model = model
            this.View.AddSubviews (new UIView[]{button, pickerView});
        }
        void Method (object sender, eventargs e)
        {
            Console.WriteLine ("Done");
            /*If you want to make the pickerView disappear, 
            you can add a pickerView.Hide() here, and then call a method 
            to redraw the controls on the current view.*/
        }
