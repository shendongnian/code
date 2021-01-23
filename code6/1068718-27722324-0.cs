    using System.Windows.Forms;
    
    class MyCheckBox : CheckBox {
        protected override bool ShowFocusCues {
            get { return false; }
        }
    }
