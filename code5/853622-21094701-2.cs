            var targetClasses = new List<string> { ".ClassOne", ".ClassThree" };
            var targetDecls = new List<string> { "background-color" };
            var parser = new Parser();
            var sheet = parser.Parse(sample);
            foreach (var r in sheet.Rulesets)
            {
                if (targetClasses.Contains(r.Selector.ToString()))
                {
                    Debug.WriteLine(r.Selector.ToString());
                    Debug.WriteLine("{");
                    foreach (var d in r.Declarations)
                    {
                        if (targetDecls.Contains(d.Name))
                        {
                            Debug.WriteLine("\t" + d);
                        }
                    }
                    Debug.WriteLine("}");
                }
            }
