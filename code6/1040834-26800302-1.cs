        var d = "M 0,20 40,20 40,80 0,80 z";
        var split = d.Split(' ');
        string result = string.Empty;
        foreach (var element in split)
        {
            if (element.Contains(","))
            {
                var couple = element.Split(',');
                int val1, val2;
                bool isNum = int.TryParse(couple[0], out val1);
                isNum &= int.TryParse(couple[1], out val2);
                if (isNum) // could be removed and simplified if there are never "," between something else than two numbers
                {
                    result += " " + (val1 * 2).ToString() + "," + (val2 * 2).ToString();
                }
                else
                {
                    result += " " + element;
                }
            }
            else
            {
                result += " " + element;
            }
        }
        result = result.Trim();
        Console.WriteLine(result);
