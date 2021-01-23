            Console.WriteLine("\nEnter last character of triangle : ");
            char ch = Convert.ToChar(Console.ReadLine());
            if (ch >= 'a' && ch <= 'z')
            {
                ch = Convert.ToChar(ch - 32);
            }
                
            
            int numberOfLines = ch - 'A' + 1;
            var graphic = "";
   
            for (var i = 0; i < numberOfLines; i++, ch--)
            {
                var line = "";
                var tmp = "";
                for (int j = 0; j < i; j++)
                {
                    tmp += " ";
                }
                line += tmp;
                for (var j = 'A'; j < ch; j++)
                {
                    line += j.ToString();
                }
                for (var j = ch; j >= 'A'; j--)
                {
                    line += j.ToString();
                }
                line += tmp;              
                graphic += line + "\n";
            }
            Console.WriteLine(graphic);
            Console.ReadLine();
