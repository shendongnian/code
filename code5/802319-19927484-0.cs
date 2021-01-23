    public override Type BindToType(string assemblyName, string typeName)
            {
                var m = Regex.Match(typeName, @"^(?<gen>[^\[]+)\[\[(?<type>[^\]]*)\](,\[(?<type>[^\]]*)\])*\]$");
                if (m.Success)
                { // generic type
                    var gen = GetFlatTypeMapping(m.Groups["gen"].Value);
                    var genArgs = m.Groups["type"]
                        .Captures
                        .Cast<Capture>()
                        .Select(c =>
                            {
                                var m2 = Regex.Match(c.Value, @"^(?<tname>.*)(?<aname>(,[^,]+){4})$");
                                return BindToType(m2.Groups["aname"].Value.Substring(1).Trim(), m2.Groups["tname"].Value.Trim());
                            })
                        .ToArray();
                    return gen.MakeGenericType(genArgs);
                }
                return GetFlatTypeMapping(assemblyName,typeName);
            }
