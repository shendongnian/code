        // Step 1: Getting some input
        String input = "123.4533wefwe";
        // Step 2: Get rid of the trail 
        Regex r = new Regex(@"^([+-][0-9]+\.?[0-9]*).*$", RegexOptions.IgnoreCase);
        MatchCollection matches = r.Matches(input);
        if (matches.Count > 0) {
            Match match = matches[0];
            GroupCollection groups = match.Groups;
            
            // Step 3: create a real decimal from the string
            decimal i;
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.Number;
            culture = CultureInfo.CreateSpecificCulture("en-GB");
            
            String matchedNumber = groups[1].Value;
            if (decimal.TryParse(matchedNumber, style, culture, out i)) {
               // Step 4: giving back the result: 
               Console.WriteLine("Parsed decimal: " + i);
            }            
        }
