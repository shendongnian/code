    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace MessagePump
    {
        class Program
        {
            static void Main(string[] args)
            {
                MessagePump p = new MessagePump();
                p.Start();
                p.AddMessage(() => Console.WriteLine("message 1"));
                p.AddMessage(() => Console.WriteLine("message 2"));
                p.AddMessage(() => Console.WriteLine("message 3"));
    
                Console.ReadLine();
                p.Stop();
            }
        }
    
        class MessagePump
        {
            bool m_Working = false;
            Queue<Action> m_Actions = new Queue<Action>();
    
            public void Start()
            {
                m_Working = true;
                Thread t = new Thread(DoPump);
                t.Name = "Message Pump Thread";
                t.Start();
            }
            void DoPump()
            {
                while (m_Working)
                {
                    try
                    {
                        Monitor.Enter(m_Actions);
                        while (m_Actions.Count > 0)
                        {
                            m_Actions.Dequeue()(); //dequeue and invoke a delegate
                        }
                    }
                    finally
                    {
                        Monitor.Exit(m_Actions);
                    }
    
                    Thread.Sleep(100); //dont want to lock this core!
                }
            }
            public void Stop()
            {
                m_Working = false;
            }
    
            public void AddMessage(Action act)
            {
                lock (m_Actions)
                {
                    m_Actions.Enqueue(act);
                }
            }
        }
    }
