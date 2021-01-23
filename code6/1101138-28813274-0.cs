    Regex r = new Regex("(\\w+) (\\w+)[ -]?(\\w+)?");
    string name = "John Anderson Johnson";
    Match m = r.Match(name);
    if(m.Success)
    {
       string first_name = m.Groups[1].Value;
       string last_name = m.Groups[2].Value;
       string last_name2 = ((m.Groups.Count > 2 && !m.Groups[3].Value.Equals(String.Empty)) ? m.Groups[3].Value : String.Empty);
       // format as desired
       string email = String.Format("{0}.{1}{2}@domain.com", first_name, last_name, (!last_name2.Equals(String.Empty)) ? "." + last_name2 : String.Empty);
       string email2 = String.Format("{0}.{1}@domain.com", first_name, last_name);
       Console.WriteLine(email);
       Console.WriteLine(email2);
    }
