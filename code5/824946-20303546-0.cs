    private void OnTimedEvent()
    {
                int pulse = rnd.Next(0, 200);
                Console.WriteLine(pulse);
                if (pulse > 50 && pulse <= 190)
                {
                    Thread.Sleep(5000);
                }
                else if (pulse <= 50 && pulse > 0 || pulse > 190)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine(timeRemaining--);
                        Console.Beep();
                        if (timeRemaining == 0)
                        {
                            Console.WriteLine("Alert sent!!");
                            j = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Alert sent!!");
                    j = 0;
                }
    }
