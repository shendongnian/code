    private bool ValidateChildren()
     {
       bool IsValid = true;
       // Clear error provider only once.
       usrError.Clear(); 
         
       //use if condition for every condtion, dont use else-if
       if (string.IsNullOrEmpty(usrTxtBox.Text.Trim()))
          {
           usrError.SetError(usrTxtBox, "field required!"); 
           IsValid =false;              
          }
    
       if (!Regex.IsMatch(usrTxtBox.Text, "</REGEX PATTERN/>"))
          {            
           usrError.SetError(usrTxtBox, "</ERROR MESSAGE/>");
            IsValid =false; 
          }
        return IsValid ;
      }
