    [Serializable]
    class Program : ISerializable
    {
        public Program() { }
        public Queue<int> Queue = new Queue<int>(); 
        private unsafe static void Main(string[] args)
        {
            var pr = new Program();
            pr.Queue.Enqueue(1034);
            using (var stream = File.Create("path.txt"))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, pr);
            }
            using (var stream = File.Open("path.txt", FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                pr = (Program)bformatter.Deserialize(stream);
            }
            Console.WriteLine("program " + pr.Queue.Peek()); //prints 1034
            Console.Read();
        }
        public Program(SerializationInfo info, StreamingContext ctxt)
        {
            Queue = (Queue<int>)info.GetValue("queue", typeof(Queue<int>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("queue", Queue);
        }
    }
