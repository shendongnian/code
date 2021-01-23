        static void Level_1()
        {
            Console.Clear();
            _Questions1 = new List<Question>();
            string filename = @"Files\question1.txt";
            Question question = new Question();
            using (FileStream f = File.Open(filename, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(f))
                {
                    string read = sr.ReadLine();
                    int qNum = 1;
                    while (read != null)
                    {
                        switch (qNum)
                        {
                            case 1:
                                question.q_no = read;
                                break;
                            case 2:
                                question.question = read;
                                break;
                            case 3:
                                question.choices = read;
                                break;
                            case 4:
                                question.answer = read;
                                _Questions1.Add(question);
                                question = new Question();
                                qNum = -1;
                                break;
                        }
                        qNum++;
                    }
                }
                int qqNum = 0;
                do
                {
                    question = _Questions1[qqNum];
                    Console.WriteLine(question.q_no);
                    Console.WriteLine(question.question);
                    Console.WriteLine(question.choices);
                    user_input = Convert.ToInt32(Console.ReadLine());
                    if (user_input == Convert.ToInt32(question.answer))
                    {
                        score += 2;
                        qqNum++;
                        Console.WriteLine("\nCongratulations you have answered correctly, scored 2 points and advanced to level 2!");
                        Console.WriteLine("Score = {0}, Questions Asked = {1}", score, asked);
                    }
                    if (user_input != Convert.ToInt32(question.answer))
                    {
                        Console.WriteLine("\nUnfortunately you are incorrect and remain at level 1, please try again!");
                        pos++;
                        asked++;
                        Level_1();
                    }
                } while (qqNum < _Questions1.Count);
            }
        }
