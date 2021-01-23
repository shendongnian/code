    Start:
            int num03;
            int num04;
            int answer;
            Console.Write("what is ");
            string input = Console.ReadLine();
            num03 = Convert.ToInt32(input);
            Console.CursorLeft = "what is ".Length + input.Length;
            Console.CursorTop--;
            Console.Write(" divided by ");
            num04 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("is the answer? ");
            answer = Convert.ToInt32(Console.ReadLine());
            if (num03 / num04 < answer)
            {
                Console.WriteLine("a bit lower next time");
                Console.WriteLine("");
                Console.WriteLine("");
                goto Start;
            }
            else if (num03 / num04 > answer)
            {
                Console.WriteLine("a bit higher next time");
                Console.WriteLine("");
                Console.WriteLine("");
                goto Start;
            }
            else if (num03 / num04 == answer) ;
            {
                Console.WriteLine("correct!!! please try another");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            goto Start;
