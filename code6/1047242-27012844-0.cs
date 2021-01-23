    public class YourUserControl
        {
            //This code will be in designer class 
            private Label lblYourLabelToHide = new Label();
    
    
            //Create this public property to hide the label
            public bool IsLabelVisible
            {
                set { lblYourLabelToHide.Visible = value; }
            }
    
    
        }
    
        public class YourParentForm
        {
            //This will be in designer
            private YourUserControl userControl = new YourUserControl();
    
            public void Form_Load()
            {
                //based on some criteria
                userControl.IsLabelVisible = false;
            }
        }
