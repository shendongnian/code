            var lowerchar = "abcdefghijklmnopqrstuvwxyz";
            var upperchar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(lowerchar, 3)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            result += new string(
                Enumerable.Repeat(upperchar, 3)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
             result += new string(
                Enumerable.Repeat(numbers, 2)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
             
            random = new Random();
            string password = new string(result.ToCharArray().OrderBy(s => random.Next().ToArray());
