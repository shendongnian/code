    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            
        }
    
        public bool Mandatory { get; set; }
    
        public override String Text
        {
            get
            {
                return base.Text + " *";
            }
        }    
    }
