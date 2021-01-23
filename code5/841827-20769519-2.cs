    public partial class fmnumbergamer: Form {
      ...
      
      //TODO: Change property name to more appropriate one
      public int LotteryValue {
        get {
          //TODO: Check if I've put the right text box here
          return int.Parse(txtinformacao.Text);
        }
        set {
          if ((value < 1) || (value > 50))
            throw new ArgumentOutOfRangeException("value"); 
          //TODO: Check if I've put the right text box here 
          txtinformacao.Text = value.ToString();
        }
      }
    
      ...
    } 
