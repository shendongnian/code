       decimal moneyvalue = 1921.39m;
        string html = String.Format("Order Total: {0:C}", moneyvalue);
        Console.WriteLine(html);
    or
        decimal value = 123.45M;
            CultureInfo us = CultureInfo.GetCultureInfo("en-US");
            string s = string.Format(us, "{0:C}", value);
