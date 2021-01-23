      /// <summary>
      /// Method to display the results in the RichTextBox, prefixed with "Results: " and with the 
      /// letters J, Q, X and Z underlined.
      /// </summary>
      private void DisplayResults(string resultString)
      {
         resultString = UnderlineSubString(resultString, "J");
         resultString = UnderlineSubString(resultString, "Q");
         resultString = UnderlineSubString(resultString, "X");
         resultString = UnderlineSubString(resultString, "Z");
         rtbResults.Rtf = @"{\rtf1\ansi " + "Results: " + resultString + "}";
      }
      /// <summary>
      /// Method to apply RTF-style formatting to make all occurrences of a substring in a string 
      /// underlined. 
      /// </summary>
      private static string UnderlineSubString(string theString, string subString)
      {
         return theString.Replace(subString, @"\ul " + subString + @"\ul0 ");
      }
