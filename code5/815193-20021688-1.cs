    public class Person {
      string firstName;
      public string FirstName {
         get { return firstName; }
         set {
               firstName = value;
               IsOdd = value.Length % 2 != 0;//Note use IsOdd not isOdd
             }
      }
      bool isOdd;
      public bool IsOdd {
        get { return isOdd; }
        private set { 
             if(isOdd != value){
               isOdd = value;
               OnIsOddChanged(EventArgs.Empty);
             }
        }
        public event EventHandler IsOddChanged;
        protected virtual void OnIsOddChanged(EventArgs e) {
          var handler = IsOddChanged;
          if (handler != null) handler(this, e);
        }        
    }
