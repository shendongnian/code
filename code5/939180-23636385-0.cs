                var serialText = new StringBuilder();
            serialText.Append("Foo\n");
            serialText.Append("Bar\r");
            serialText.Append("Baz\r\n");
            serialText.AppendFormat("Pok{0}", Environment.NewLine);
            serialText.AppendLine("Zok");
            string[] serials = serialText.ToString().Split(Environment.NewLine.ToCharArray());
            foreach (var s in serials)
                Console.WriteLine(s);
            Console.ReadKey();
