    using (StreamReader Date = new StreamReader("C:\\DateParse.txt")  
            while((line = Date.ReadLine()) != null)  
                if (DateTime.TryParseExact(line.Trim(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal, out DateTime))  
                    Console.WriteLine("True");  
                else  
                    Console.WriteLine("False"); 
