            var str = "asdasdasd";
            using (var sw = new StreamWriter("file.txt"))
            {
                var temp = str;
                if (temp.Length > 1024)
                {
                    temp = temp.Substring(0, 1024);
                    Console.WriteLine("Limit reached");
                }
                sw.Write(temp);
            }
