        String s1= "Event: 1 - Some event";
        String s2=  "Event 12 -";
        String s3= "Event: 123";
        String s4=  "Event: 12 - Some event 3";
        String result1 = System.Text.RegularExpressions.Regex.Match(s1, @"\d+").Value;
        String result2 = System.Text.RegularExpressions.Regex.Match(s2, @"\d+").Value;
        String result3 = System.Text.RegularExpressions.Regex.Match(s3, @"\d+").Value;
        String result4 = System.Text.RegularExpressions.Regex.Match(s4, @"\d+").Value;
