    public void Input()
            {
                bool hasNumber = false;
                while (!hasNumber)
                {
                    string input = Console.ReadLine().Trim();
                    try
                    {
                        n = Convert.ToInt32(input);
                        hasNumber = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(input + " Is not a number");
                    }
                }
                //n = int.Parse(Console.ReadLine());
                S temp = new S();
                first = temp;
                for (int i = 0; i < n; i++)
                {
                    temp.power = i;
                    temp.koef = int.Parse(Console.ReadLine()); //<< you'll have to fix this one yourself
                    temp.next = new S();
                    temp = temp.next;
                    if (i != n - 1)
                        temp = new S();
                }
            }
