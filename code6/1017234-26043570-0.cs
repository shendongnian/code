    static string uniqueCode()
    {
        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#";
        string ticks = DateTime.UtcNow.Ticks.ToString();
        var code = "";
        for (var i = 0; i < characters.Length; i += 2)
        {
            if ((i + 2) <= ticks.Length)
            {
                var number = int.Parse(ticks.Substring(i, 2));
                if (number > characters.Length - 1)
                {
                    var one = double.Parse(number.ToString().Substring(0, 1));
                    var two = double.Parse(number.ToString().Substring(1, 1));
                    code += characters[Convert.ToInt32(one)];
                    code += characters[Convert.ToInt32(two)];
                }
                else
                    code += characters[number];
            }
        }
        return code;
    }
