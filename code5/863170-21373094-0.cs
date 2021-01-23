    static void Main(string[] args)
        {
            int bullet = 1;
            StringBuilder Assembler = new StringBuilder();
            List<string> myList = new List<string>();
            //THIS NULL IS INTENTIONAL
            myList.Add(null);
            myList.Add("Oranges");
            myList.Add("Banana");
            // Purposefully adding an extra character in the beginning of the string to
            // differtiate it.
            myList.Add("`" + "This is a Comment and I do not want to add a bullet to it.");
            foreach (string item in myList)
            {
                if (item != null)
                {
                    if (item.StartsWith("`"))
                    {
                        Assembler.AppendLine(item.Substring(1, item.Length - 1));
                    }
                    else
                    {
                        Assembler.AppendLine("(" + bullet++ + ") " + item);
                    }
                }
            }
            Console.Write(Assembler.ToString());
            Console.ReadKey();
        }
