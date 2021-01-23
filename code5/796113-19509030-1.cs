      String str1 = "First Second [insideFirst] Third Forth [insideSecond] Fifth";
        var output = String.Join(";", Regex.Matches(str1, @"\[(.+?)\]")
                                    .Cast<Match>()
                                    .Select(m => m.Groups[1].Value));
        string[] strInsideBreacket = output.Split(';');
        for (int i = 0; i < strInsideBreacket.Count(); i++)
        {
            str1 = str1.Replace("[", ";");
            str1 = str1.Replace("]", "");
            str1 = str1.Replace(strInsideBreacket[i], "");
        }
        string[] strRemaining = str1.Split(';');
