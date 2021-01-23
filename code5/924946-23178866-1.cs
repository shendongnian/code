    public partial class Form1
    {
            public Form1()
            {
                    myCustomButton.MyClick += FireThisOnClick;
            }
    
            private void FireThisOnClick(object sender, EventArgs e)
            {
                    //this will be executed on click
            }
    }
