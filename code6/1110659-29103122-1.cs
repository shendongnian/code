    foo.Select(x =>
                   {
                       var elements = x.Descendants(namespace + "bar");
                       return new
                       {
                          bars = elements != null ? elements.Select(z => z.Value).ToArray() : new string[0]
                       }
                    })
                .ToArray();
