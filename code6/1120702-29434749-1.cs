    public class MySpecialString
    {
        private string _userEntered;
        public string VisibleText 
        {   
           get
           {
             return _userEntered;
           }
           set
           {
              _userEntered = value;
               //set your added text  value here...
              AddedText = "&123";  //example
           }
         }
        public string AddedText {get; private set; }
        
        public override string ToString()
        {
          return VisibleText;
        }
     }
