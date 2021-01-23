      public partial class Form1 {
        ...
        private void myCheckBox_CheckedChanged(object sender, EventArgs e) {
          foreach(Form f in Application.OpenForms) {
            Form2 form2 = f as Form2; 
    
            if (form2 != null)
              form2.IsMyButtonVisible = myCheckBox.Checked;
          }
        }
        ...
      } 
