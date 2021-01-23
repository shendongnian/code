    using System.Threading.Tasks;
    static void Main(String[] args)
            { 
                Task t1 = new Task(Function2);
                Task t2 = new Task(Function3);
                t1.Start();
                t2.Start();
            }
