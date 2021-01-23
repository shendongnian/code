    Cookie c = new Cookie();
    c.NameValue = new Dictionary<string,string>();
    Regex.Matches(cookie, @"(\w+)=?([^;]*)")
                    .OfType<System.Text.RegularExpressions.Match>()
                    .Select(m => new 
                    {
                        Key = m.Groups[1].Value,
                        Value = m.Groups.Count > 2 ? m.Groups[2].Value : null,
                        Field = typeof(Cookie).GetField(m.Groups[1].Value)
                    })
                    .ToList()
                    .ForEach(x =>
                    {
                        if (x.Field != null)
                            x.Field.SetValue(c, 
                                        x.Field.FieldType != typeof(bool) ?
                                        (object)x.Value : true
                                        );
                        else
                            c.NameValue.Add(x.Key, x.Value);
                    });
