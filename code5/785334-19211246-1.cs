            String[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            Dictionary<string, int> hours = new Dictionary<string, int>();
            for (int i = 0; i < days.Length; i++)
            {
                int dailyHours;
                Console.Write("{0}'s study hours: ", days[i]);
                while (int.TryParse(Console.ReadLine(), out dailyHours) != true)
                {
                    Console.WriteLine("Wrong input,must be only numbers!!!");
                    Console.Write("{0}'s study hours: ", days[i]);
                }
                //if(int.TryParse(Console.ReadLine(),out dailyHours))
                hours.Add(days[i], dailyHours);
            }
