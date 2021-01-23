     public partial class UserControl1 : UserControl
            {
                public static UserControl1 Instance
                {
                    get;
                    private set;
                }
         Public String CName = "ABC";
                public UserControl1()
                {
        
                    if (Instance != null)// there should be just one instance
                        throw new NotSupportedException();
                    Instance = this;
        
                    InitializeComponent();
                }
            }
    enter code here
