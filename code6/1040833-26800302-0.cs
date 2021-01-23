        var d = "M 0,20 40,20 40,80 0,80 z";
        var split = d.Split(' ');
        string result = string.Empty;
        foreach (var element in split)
        {
            double val;
            bool isNum = double.TryParse(element, out val); // Works as expected only for cultures with "," as decimal separator !
            if (isNum)
            {
                val = val * 2;
                result += " " + val.ToString("N2");
            }
            else
            {
                result += " " + element;
            }
        }
        result.Trim();
        Console.WriteLine(result);
