     public class IPTextBox : TextBox
        {
            public IPTextBox() : base()
            {
             
            }
                  
            protected override CreateParams CreateParams
            {
                get
                {
                    new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
                    CreateParams cp = base.CreateParams;
                    cp.ClassName = "SysIPAddress32";
                    return cp;
                }
            }
            
    
        }
