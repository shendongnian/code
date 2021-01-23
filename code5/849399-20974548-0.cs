    public class SomeClass : Form
    {
        private float YourFloat;
    
        private void SomeMethod()
        {
            YourFloat = 123;
        }
    
        protected void BtnButton_OnClick(object sender, EventArgs e)
        {
            // Do something with YourFloat (Contains 123);
        }
    }
