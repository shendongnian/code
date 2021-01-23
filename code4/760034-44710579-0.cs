    {
            Console.WriteLine("perfect numbers/n");
            Console.Write("Enter upper limit: ");
            int iUpperLimit = int.Parse(Console.ReadLine());
            string sNumbers = "";
            List<int> lstFactor = new List<int>();
            for(int i = 1;i<=iUpperLimit;i++)
            {
                for(int k = 1;k<i;k++)
                {
                    if (i % k == 0)
                    {
                        lstFactor.Add(k); //this collect all factors
                    }
                    if (k == i-1)
                    {
                        if (lstFactor.Sum() == i) //explain1
                        {
                            sNumbers += " " + i;
                            lstFactor.Clear(); //explain2
                            break;
                        }
                        else
                        {
                            lstFactor.Clear(); //explain2
                        }
                    }
                }
            }
            Console.WriteLine("\nperfect numbers are: " + sNumbers);
            Console.ReadKey();
        }
    }
