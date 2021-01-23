    using System;
    using System.IO;
    namespace ConsoleApp1
    {
        public sealed class Node
        {
            public byte Symbol { get; set; }
            public int Count   { get; set; }
            public Node Next   { get; set; }
        }
        sealed class Program
        {
            private void run()
            {
                var linkedList = new Node();
                string filename = @"C:\Test\t.cs";
                foreach (byte symbol in File.ReadAllBytes(filename))
                    addSymbol(symbol, linkedList);
                for (int symbol = 0; symbol < 256; ++symbol)
                {
                    int count = countForSymbol((byte)symbol, linkedList);
                    Console.WriteLine("Symbol {0} occurred {1} times.", symbol, count);
                }
            }
            private static void addSymbol(byte symbol, Node head)
            {
                Node last = head;
                while (head != null)
                {
                    last = head;
                    if (head.Symbol == symbol)
                    {
                        ++head.Count;
                        return;
                    }
                    else
                    {
                        head = head.Next;
                    }
                }
                last.Next = new Node
                {
                    Symbol = symbol, 
                    Count = 1
                };
            }
            private int countForSymbol(byte symbol, Node head)
            {
                while (head != null)
                {
                    if (head.Symbol == symbol)
                        return head.Count;
                    else
                        head = head.Next;
                }
                return 0;
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
