    public partial class Form1: Form {
      ...
    
      // textBox1 is private (we can't access in from Form2) 
      // so we'd rather create a public property
      // in order to have an access to textBox1.Readonly
      public Boolean IsLocked {
        get {
          return textBox1.Readonly;
        }
        set {
          textBox1.Readonly = value;
        }
      }
    }
    
    ...
    
    public partial class Form2: Form {
      ...
    
      private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        // When checkBox1 checked state changed,
        // let's find out all Form1 instances and update their IsLocked state
        foreach (Form fm in Application.OpenForms) {
          Form1 f = fm as Form1;
    
          if (!Object.RefrenceEquals(f, null))
            f.IsLocked = checkBox1.Checked;
        }  
    
      }
    }
