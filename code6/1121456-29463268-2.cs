    public class Player
    {
      private string _name;
      private System.Windows.Forms.RadioButton _myRadioButton;
      private System.Windows.Forms.Label _myLabel;
      public Player(string name, System.Windows.Forms.RadioButton myRadioButton, 
                                 System.Windows.Forms.Label myLabel)
      {
        _name = name;
        _myRadioButton = myRadioButton;
        _myLabel = myLabel;
      }
    }
