    class Program
    {
        static void Main(string[] args)
        {
            RunInSta(() =>
            {
                var dataObject = Clipboard.GetDataObject();
                foreach (string format in dataObject.GetFormats())
                {
                    Console.WriteLine(format);
                }
            });
        }
        internal static void RunInSta(Action action)
        {
            Thread thread = new Thread(() => action());
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
