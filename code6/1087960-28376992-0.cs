    public class App
    {
        // more code could be here
 
        public App()
        {
             PhoneApplicationFrame rootFrame = (Application.Current as App).RootFrame;
             rootFrame.Obscured += OnObscured;
             rootFrame.Unobscured += Unobscured;
        }
        // and some code could be here
        void OnObscured(Object sender, ObscuredEventArgs e)
        {    
        }
        void Unobscured(Object sender, EventArgs e)
        {    
        }     
 
        // and even here
    }
