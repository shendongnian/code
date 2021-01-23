        var splittedString = " and x = 'o'reilly' and y = 'o'reilly' and z = 'abc' ".Split(new char[] {' '},
                                                                                           StringSplitOptions
                                                                                               .RemoveEmptyEntries);
        List<string> listStrings = splittedString.Select(s => s.Trim('\'').Replace('\'', '"')).ToList();
        var finalResult = "";
        var prevMatchIsEqualToSign = false;
        foreach (var s in listStrings)
        {
            if (prevMatchIsEqualToSign)
            {
                finalResult += "'" + s + "' ";
            }
            else if (s == "=")
            {
                finalResult += "= ";
                prevMatchIsEqualToSign = true;
                continue;
            }
            else
            {
                finalResult += s +" ";
            }
            prevMatchIsEqualToSign = false;
        }
        Console.WriteLine(finalResult);
