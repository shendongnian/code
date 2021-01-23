    public class SomeClass: Callback
    {
        public SomeClass()
        {
           Button b = new Button(this);
        }
    
    
        void OnClick(Button button)
        {
            Debug.Log("Clicked");
        }
    
    }
