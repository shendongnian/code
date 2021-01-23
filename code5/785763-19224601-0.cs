    public void Test(int option, string parameter)
    {
        var data = new[] { new { Text = "Unknown option", Value = -1 } };
        switch(option)
        {
            case 2:
                data = Enumerable.Range(1, 4)
                                 .Select(x => new { Text = x.ToString(), Value = x })
                                 .ToArray();
                break;
            case 3:
                data = (new Random()).Next(2) % 2 == 1
                    ? Enumerable.Range(1, 6)
                                .Select(x => new { Text = x.ToString(), Value = x })
                                .ToArray()
                    : Enumerable.Range(1, 2)
                                .Select(x => new { Text = x.ToString(), Value = x })
                                .ToArray();
                break;
            default:
                data = Enumerable.Range(1, 3)
                                 .Select(x => new { Text = x.ToString(), Value = x })
                                 .ToArray();
                break;
        }
    }
