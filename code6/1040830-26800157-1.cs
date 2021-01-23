            var d = "M 0,20 40,20 40,80 0,80 z";
            d = Regex.Replace(d, "([0-9]{0,})", (m) =>
            {
                int i;
                if (int.TryParse(m.Value, out i))
                {
                    return (2*i).ToString();
                }
                return m.Value;
            }, RegexOptions.None);
            Console.WriteLine(d);
