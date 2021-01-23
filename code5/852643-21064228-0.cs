    public class MyForm : Form {
     bool DotAlreadyExists {
       get {
         return remainTxt.Contains("."); 
       }
     }
     void OnClick(object sender, EventArgs e) {
      var button (sender as Button); 
      if(button != null) {
        string toAppend = button.Text; 
        if(!String.Equals(toAppend, ".")) {
          AppendValue(toAppend);
        }
         else {
         if(!DotAlreadyExists) {
        AppendValue(toAppend);
     }
    
       }
      }
     }
    }
