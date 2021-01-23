    public partial class fmnumbergamer: Form {
      ...
      
      //TODO: Change property name to more appropriate one
      public String TextBoxValue {
        get {
          //TODO: Check if I've put the right text box here
          return txtinformacao.Text;
        }
        set {
          //TODO: Check if I've put the right text box here
          txtinformacao.Text = value;
        }
      }
    
      ...
    } 
