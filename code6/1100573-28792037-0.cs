    //to use extension methods do: serialPort.ReadKnownLength(3);
    public static class SerialPortExtensions
    {
        public static int[] ReadUnknownLength(this SerialPort serialPort)
        {
            var list = new List<int>();
            while (true)
            {
                try
                {
                    var input = serialPort.ReadLine();
                    //change the condition to your own break condition
                    if (String.IsNullOrEmpty(input))
                        break;
                    list.Add(int.Parse(input));
                }
                catch (TimeoutException)
                {
                }
            }
            // if you don't need to reorder
            //return list.ToArray();
            
            var result = new int[list.Count];
            for (var i = 0; i < result.Length; i++)
            {
                //reorder the input(you did it in your question...)
                result[i] = list[list.Count - (i + 1)];
            }
            return result;
        }
        //match your answer behavior
        public static int[] ReadKnownLength(this SerialPort serialPort, int length)
        {
            var result = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {
                result[i] = Int32.Parse(serialPort.ReadLine());
            }
            return result;
        }
    }
