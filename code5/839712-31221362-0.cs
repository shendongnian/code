    class Program
    {
        static void Main(string[] args)
        {
            using (MPI.Environment environment = new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                if (comm.Rank == 0)
                {
                    int [] numbers = new int[comm.Size];
                    for (int k = 0; k < numbers.Length; k++)
                        numbers[k] = k * k;
                    int r = comm.Scatter(numbers);
                    Console.WriteLine("Received {0} at {1}", r, comm.Rank);
                }
                else
                {
                    int r = comm.Scatter<int>(0);
                    Console.WriteLine("Received {0} at {1}", r, comm.Rank);
                }
            }
        }
    }
