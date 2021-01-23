    var str = "Hello@Hello&Hello(Hello)";
    var characters = str.Select(c =>
            {
                if (!char.IsLetter(c)) return ',';
                return c;
            }).ToArray();
                    
       var output = new string(characters);
       Console.WriteLine(output);
