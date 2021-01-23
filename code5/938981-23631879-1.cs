    string fullName = "BELAMONTE VALVERDE Allechandro Jesus";
    string[] words = fullName.Split(' ');
    StringBuilder sb = new StringBuilder();
    foreach (string word in words)
        if (word.ToUpper() == word)
        {
            sb.Append(word + " ");
        }
        else
            break; // That's assuming you will never have a last name's part after a first name's part :p
    sb.Length--; // removes the last " " added in the loop, but maybe you want it ;)
    Console.WriteLine(sb.ToString());
