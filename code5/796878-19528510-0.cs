    public static int TextToMins(string timeText)
    {
        var total = 0;
        foreach (var part in timeText.Split(' '))
        {
            if (part[part.Length - 1] == 'h')
            {
                total += 60 * int.Parse(part.Trim('h'));
            }
            else
            {
                total += int.Parse(part.Trim('m'));
            }
        }
        return total;
    }
