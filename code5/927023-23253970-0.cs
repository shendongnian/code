    public class MyScreenViewModel : INotifyPropertyChanged
    {
      private const string RegexExpression = "^[A-Za-z]{2}[0-9]{5}$"; 
    
      public bool UserInputIsValid { get { stuff; } set { stuff; }}
      public string UserInput { get { stuff; } set { stuff; ValidateUserInput();} }
    
      private void ValidateUserInput()
      {
        if (UserInput == null)
        {
            return false;
        }
        var regex = new Regex(RegexExpression, RegexOptions.None);
        UserInputIsValid = regex.IsMatch(UserInput);
      }
    }
