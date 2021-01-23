    string[] separators = new string[] { ",",  "!", "\'", " ", "\'s" };
    foreach (string word in element.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
      {
         //Split the each work and validate Name , Email, Phone Number.
        bool Name = Regex.IsMatch(word, @"^[\p{L} \.\-]+$", RegexOptions.IgnoreCase);
        if (Name)
          {
             if (fileContentModel.FIRST_NAME == null)
               {
                  fileContentModel.FIRST_NAME = word;
               }
             else if(fileContentModel.LAST_NAME ==null)
               {
                  fileContentModel.LAST_NAME = word;
               }
           }
         bool isEmail = Regex.IsMatch(word, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
         if (isEmail)
         {
           fileContentModel.EMAIL = word;
         }
         bool isPhoneNumber = Regex.IsMatch(word, @"(\([2-9]\d\d\)|[2-9]\d\d) ?[-.,]? ?[2-9]\d\d ?[-.,]? ?\d{4}", RegexOptions.IgnoreCase);
         if (isPhoneNumber)
         {
            fileContentModel.PHONE = word;
         }
      }
