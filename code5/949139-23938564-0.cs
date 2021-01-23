          int indexof = -1;
            String input = "3492883#32280948093284#990303294";
            string[] numbers = input.Split('#');
            foreach(string n in numbers)
            {
                Match m=Regex.Match(n, @"(\d)\1+");
                if (m.Success)
                {
                    indexof = m.Index;
                }
            
            }
