    using System;
    using System.Threading;
    using SynchronizingCollection.Common.Model;
    using XSockets.Client40;
    namespace SynchronizingCollection.Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                var c = new XSocketClient("ws://127.0.0.1:4502","http://localhost","demo");
                c.Controller("demo").OnOpen += (sender, connectArgs) => Console.WriteLine("Demo OPEN");
                c.Controller("demo").On<MyModel>("addorupdated", model => Console.WriteLine("Updated " + model.Name));
                c.Controller("demo").On<MyModel>("removed", model => Console.WriteLine("Removed " + model.Name));
                c.Open();
                for (var i = 0; i < 10; i++)
                {
                    var m = new MyModel() {Id = Guid.NewGuid(), Name = "Person Nr" + i, Age = i};
                    c.Controller("demo").Invoke("AddOrUpdateModel", m);
                    Thread.Sleep(2000);
                    c.Controller("demo").Invoke("RemoveModel", m);
                    Thread.Sleep(2000);
                }
                Console.ReadLine();
            }
        }
    }
