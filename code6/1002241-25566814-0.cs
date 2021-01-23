    string str = "asjlfkajs alsdkfja s asldfkjas @abc dfasldkfj asldkfj las @nveweb dfasdlf asldfj.";
                string[] split = str.Split(' ');
                for(int i = 0; i < split.Length; i++)
                {
                    if(split[i].StartsWith("@"))
                    {
                        split[i] = "$" + split[i] + "$";
                    }
                }
                string result = String.Join(" ", split);
                Console.WriteLine(result);
                Console.ReadLine();
