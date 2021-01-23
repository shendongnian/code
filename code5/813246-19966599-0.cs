    public Form1() {
       var childForm = new ChildForm();
       childForm.DontSave += // event handler
    }
    
    class ChildForm : Form {
    
       public event EventHandler DontSave {
          add { dontSaveButton.Click += value; }
          remove { dontSaveButton.Click -= value; }
       }
    
    }
