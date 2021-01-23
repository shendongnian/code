    string text= @"m\an1oj ku\mar m\a\no9j";
    char[] shiftPressForms = ")!@#$%^&*(".ToCharArray();
    Regex pattern = new Regex(@"([a-z])\\");
    Regex pattern_digit = new Regex(@"\d");
    string replaced = pattern.Replace(text, m => m.Groups[1].ToString().ToUpper());
    replaced = pattern_digit.Replace(replaced, m => shiftPressForms[int.Parse(m.Value)].ToString());
    Console.WriteLine(replaced);
