            var xdoc = XDocument.Load("Alarms.xml");
            foreach (var x in xdoc.Root.Elements("Alarm")) {
                Console.WriteLine(x.ToString());
                var date = x.Element("Date");
                var time = x.Element("Time");
                Console.WriteLine("Date = {0}", date == null ? "<empty>": date.Value);
                Console.WriteLine("Time = {0}", time == null ? "<empty>": time.Value);
                }
