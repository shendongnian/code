    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace DogPark
    {
        internal class DogPark
        {
    
            private readonly string _parkName;
            private readonly Thread _thread;
            private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
            private volatile bool _isOpen;
    
            public DogPark(string parkName)
            {
                _parkName = parkName;
                _isOpen = true;
                _thread = new Thread(OpenPark);
                _thread.Name = parkName;
                _thread.Start();
            }
    
            // Runs in "target" thread
            private void OpenPark(object obj)
            {
                while (true)
                {
                    Action action;
                    if (_actions.TryDequeue(out action))
                    {
                        Program.WriteLine("Something is happening at {0}!", _parkName);
                        try
                        {
                            action();
                        }
                        catch (Exception ex)
                        {
                            Program.WriteLine("Bad dog did {0}!", ex.Message);
                        }
                    }
                    else
                    {
                        // Nothing left!
                        if (!_isOpen && _actions.IsEmpty)
                        {
                            return;
                        }
                    }
    
                    Thread.Sleep(0); // Don't toaster CPU
                }
            }
    
            // Called from external thread
            public void DoItInThePark(Action action)
            {
                if (_isOpen)
                {
                    _actions.Enqueue(action);
                }
            }
    
            // Called from external thread
            public void ClosePark()
            {
                _isOpen = false;
                Program.WriteLine("{0} is closing for the day!", _parkName);
                // Block until queue empty.
                while (!_actions.IsEmpty)
                {
                    Program.WriteLine("Waiting for the dogs to finish at {0}, {1} actions left!", _parkName, _actions.Count);
    
                    Thread.Sleep(0); // Don't toaster CPU
                }
                Program.WriteLine("{0} is closed!", _parkName);
            }
    
        }
    
        internal class Dog
        {
    
            private readonly string _name;
    
            public Dog(string name)
            {
                _name = name;
            }
    
            public void Run()
            {
                Program.WriteLine("{0} is running at {1}!", _name, Thread.CurrentThread.Name);
            }
    
            public void Bark()
            {
                Program.WriteLine("{0} is barking at {1}!", _name, Thread.CurrentThread.Name);
            }
    
        }
    
        internal class Program
        {
            // "Thread Safe WriteLine"
            public static void WriteLine(params string[] arguments)
            {
                lock (Console.Out)
                {
                    Console.Out.WriteLine(arguments);
                }
            }
    
            private static void Main(string[] args)
            {
                Thread.CurrentThread.Name = "Home";
    
                var yorkshire = new DogPark("Yorkshire");
                var thunderpass = new DogPark("Thunder Pass");
    
                var bill = new Dog("Bill the Terrier");
                var rosemary = new Dog("Rosie");
    
                bill.Run();
    
                yorkshire.DoItInThePark(rosemary.Run);
                yorkshire.DoItInThePark(rosemary.Bark);
    
                thunderpass.DoItInThePark(bill.Bark);
    
                yorkshire.DoItInThePark(rosemary.Run);
    
                thunderpass.ClosePark();
                yorkshire.ClosePark();
            }
    
        }
    }
