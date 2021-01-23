    System.Text.RegularExpressions.Regex.Replace(
                    str,
                    @"\d+",
                    m => (int.Parse(m.Groups[0].Value) + 1).ToString("D" + m.Groups[0].Value.Length)
                 );
