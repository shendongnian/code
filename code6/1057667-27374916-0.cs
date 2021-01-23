    class Program {
        static void Main(string[] args) {
            var value1 = 3.49563395756763E-310;
            var bytes1 = BitConverter.GetBytes(value1);
            Console.WriteLine(BitConverter.ToString(bytes1));
            var value2 = 101.325;
            var bytes2 = BitConverter.GetBytes(value2);
            Console.WriteLine(BitConverter.ToString(bytes2));
        }
    }
