    const int TOLERANCE = 1;
    string userInput = textInput.Text.ToLower();
    var matchingPeople = people.Where(p =>
    {
         //Check Contains
         bool contains = p.Name.ToLower().Contains(userInput);
         if(contains) return true;
         //Check LongestCommonSubsequence
         bool subsequenceTolerated = p.Name.LongestCommonSubsequence(userInput).Length >= userInput.Length - TOLERANCE;
         
         return subsequenceTolerated;
    }).ToList();
