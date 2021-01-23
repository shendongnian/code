    public class OtherClass
    {
        public void RegisterUnregister
        {
            // Reference to main class
            MainWindow ref =...;
            // register event...
            ref.b.Click+=mainwinButton_click;
            // Unregister event...
            ref.b.Click-=mainwinButton_click;
        }
    }
