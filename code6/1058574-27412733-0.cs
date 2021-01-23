    private List<double> GetNumbers(string input)
    {
       // declare result
       var resultList = new List<double>();
    
       // if input is empty return empty results
       if (string.IsNullOrEmpty(input))
       {
          return resultList;
       }
    
       // Split input in to words, exclude empty entries
       var words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             
       // set your desirted culture
       var culture = CultureInfo.CreateSpecificCulture("en-GB");
    
       // Refine words into a list that represents potential numbers
       // must have decimal place, must not start or end with decimal place
       var refinedList = words.Where(x => x.Contains(".") && !x.StartsWith(".") && !x.EndsWith("."));
       foreach (var word in refinedList)
       {
          double value;
          // parse words using designated culture, and the Number option of double.TryParse
          if (double.TryParse(word, NumberStyles.Number, culture, out value))
          {
             resultList.Add(value);
          }
       }
       return resultList;
    }
