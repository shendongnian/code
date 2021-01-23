    string line = "1. Bill Monohan from North Town 10.54";
    line = Regex.Replace(line, @"(\d+\.?\d*)$", m => {
                decimal value = Decimal.Parse(m.Groups[1].Value);
                value = value * 2; // calculation
                return value.ToString();
            });
