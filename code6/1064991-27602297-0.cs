    var result = Regex.Replace(input, @"""(?:(\r\n)|[^""])+""", delegate(Match m)
                {
                    if (string.IsNullOrEmpty(m.Groups[1].Value))
                        return m.Value;
                    return m.Value.Replace("\r\n", " ");
                });
