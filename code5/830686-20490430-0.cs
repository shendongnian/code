     string UserFedData = ttextBox1.Text.Trim().ToString(); 
      //this is a regex to detect conflicting user built queries.
       var troublePattern = new Regex(@"^(\(?\d+\)?|\(?[$][^$]+[$]\)?)([+*/-](\(?\d+\)?|\(?[$][^$]+[$]\)?))*$");
       //var troublePattern = new Regex(@"var troublePattern = new Regex(@"^(?:[-]?\(*)?(?:\$[A-Za-z][A-Za-z0-9_]*\$|\d+)(?:\)*[+/*-]\(*(?:\$[A-Za-z][A-Za-z0-9_]*\$|\d+))*(?:\)*)$");
     string TroublePattern = troublePattern.ToString();
   
    //readyToGo is the boolean that indicates if further processing of data is safe or not
                            bool readyToGo = Regex.IsMatch(UserFedData, TroublePattern, RegexOptions.None);
