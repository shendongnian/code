     List<string> a = new List<string>();
            a.Add("[1] MS Excel documentation");
            a.Add("[2] MS Excel tutorial");
            a.Add("[3] MS Access documentation");
            a.Add("[4] MS Access tutorial");
            a.Add("[5] Google Chrome documentation");
            a.Add("[6] Google Product video for Chrome");
            var result = from item in a
                         let x = "MS"
                         let y = "documentation"
                         where item.Contains(x) && item.Contains(y)
                         select item;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
