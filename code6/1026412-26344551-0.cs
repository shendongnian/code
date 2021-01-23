    string consonants = "bcdfghjklmnpqrstvwxyz";
    string vowels = "aeiou";
    int vowelCount = 0, consonantCount = 0, nonNumericCount = 0;
    var input = "alsdkghanivhusrvndb";  //some input         
    foreach (char t in input)
    {
       if (consonants.Any(c => c == t))
           consonantCount++;
       else if (vowels.Any(c => c == t))
           vowelCount++;
       else
           nonNumericCount++;
    }
