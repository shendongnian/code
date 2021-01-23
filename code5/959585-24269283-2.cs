    List<string> list = root.Descendants("report")
                            .SelectMany(report =>
                            {
                                List<string> sub = new List<string>();
                                sub.Add(report.Descendants("narrative").First().Value);
                                sub.Add(report.Descendants("statement")
                                                .Where(statement => statement.Elements().Any() == false)
                                                .First().Value);
                                return sub;
                            })
                            .ToList();
