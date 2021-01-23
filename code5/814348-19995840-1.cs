    public class ChildForm
    {
       public MainForm Parent { get; set; }
    
       public string LoginName 
       {
          get
          {
             return Parent.LoginName;
          }
       } 
         
       public ChildForm(MainForm mainForm)
       {
          Parent = mainForm;
       }
    }
