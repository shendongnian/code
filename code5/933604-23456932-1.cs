                List<string> texts = new List<string>();
                texts.Add("sample text 1");
                texts.Add("sample text 2");
                // add your strings ....
                int totalLenght = 0;
                for (int i = 0; i < texts.Count; i++)
                {
                    totalLenght += texts[i].Length;
                }
                Console.WriteLine("Length is {0}", totalLenght);
