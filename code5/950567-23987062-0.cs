    string inp = "with System, System.IO, System.Text";
    string repl = Regex.Replace(
            inp, @"^with (?:(?<namespace>.+?)\s*(?:,\s*|$))*$",
                a => String.Join(
                      Environment.NewLine,
                      a.Groups["namespace"]
                        .Captures
                        .OfType<Capture>()
                        .Select(b => String.Format("using {0};", b))
                       )
                   );
    Console.WriteLine(repl);
