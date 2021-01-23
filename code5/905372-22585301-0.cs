    string s = "There was a dog. The dog ate 1000 bones. After eating, he was very sleepy. He slept for 12 hours.";
    foreach (var match in Regex.Matches(s, "[0-9]+"))
    {
        string number = match.ToString();
        s = s.Replace(number, NumberToWords(int.Parse(number)));
    }
    Console.WriteLine(s);
