    public class CustomButton : UIButton
    {
        public CustomButton()
        {
            TouchUpInside += HandleTouchUpInside;
            // or new EventHandler(HandleTouchUpInside)
            // if Xamarin compiler/runtime doesn't allow such shorter code
        }
    
        public void HandleTouchUpInside(object sender, EventArgs e)
        {
            Console.Write("test tap"); 
        }
    }
