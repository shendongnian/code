    using System;
    namespace FunnyConsoleApplication
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Airplane plane = new Airplane();
                bool reserve = true;
                while (reserve)
                {
                    Console.WriteLine("Enter [1] to fly First Class ({0} vacant)", plane.VacantFirstClassSeats());
                    Console.WriteLine("Enter [2] to fly Economy Class ({0} vacant)", plane.VacantEconomySeats());
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (plane.HasFirstClassSeats)
                            {
                                plane.ReserveFirstClassSeat();
                            }
                            else if (plane.HasEconomySeats)
                            {
                                if (IsOk("No vacancy, enter [y] to fly Economy instead?"))
                                    plane.ReserveEconomySeat();
                                else
                                    reserve = false;
                            }
                            else
                            {
                                reserve = false;
                            }
                            break;
                        case "2":
                            if (plane.HasEconomySeats)
                            {
                                plane.ReserveEconomySeat();
                            }
                            else if (plane.HasFirstClassSeats)
                            {
                                if (IsOk("No vacancy, enter [y] to fly First Class instead?"))
                                    plane.ReserveFirstClassSeat();
                                else
                                    reserve = false;
                            }
                            else
                            {
                                reserve = false;
                            }
                            break;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("No can do, good bye!");
                Console.ReadLine();
            }
            private static bool IsOk(string question)
            {
                Console.WriteLine(question);
                return string.Compare(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase) == 0;
            }
        }
        public class Airplane
        {
            private readonly bool[] _seats = new bool[10];
            public bool HasFirstClassSeats
            {
                get { return HasSeats(0); }
            }
            public bool HasEconomySeats
            {
                get { return HasSeats(5); }
            }
            public int VacantFirstClassSeats()
            {
                return GetVacant(0);
            }
            public int VacantEconomySeats()
            {
                return GetVacant(5);
            }
            public void ReserveFirstClassSeat()
            {
                Reserve(0);
            }
            public void ReserveEconomySeat()
            {
                Reserve(5);
            }
            private bool HasSeats(int index)
            {
                for (int i = index; i < index + 5; i++)
                {
                    if (!_seats[i])
                        return true;
                }
                return false;
            }
            private int GetVacant(int index)
            {
                int count = 0;
                for (int i = index; i < index + 5; i++)
                {
                    if (!_seats[i])
                        count++;
                }
                return count;
            }
            private void Reserve(int index)
            {
                for (int i = index; i < index + 5; i++)
                {
                    if (!_seats[i])
                    {
                        _seats[i] = true;
                        break;
                    }
                }
            }
        }
    }
