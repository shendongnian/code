    string line = "1. Bill Monohan from North Town 10.54";
    line = Regex.Replace(line, @"(\d+\.?\d*)$", m => {
                string value = m.Groups[1].Value;
                decimal x = Decimal.Parse(value);
                x = x * 2; // calculation
                return x.ToString();
            });
