    if(input.Length == 12) // check characters are 12
    {
     if(input.Take(3).All(x=> Char.IsLetter(x)) // First 3 are alphabets
     && input.Skip(3).All(x=>Char.IsDigit(x))) // next all numbers
       return true;
     else
      return false;
           
    }
    else
    {
      return false;
    }
