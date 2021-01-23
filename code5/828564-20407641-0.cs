    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Please copy something into the clipboard.");
            WaitForClipboardChange();
            Console.WriteLine("You copied " + Clipboard.GetText());
            Console.ReadKey();
        }
        static void WaitForClipboardChange()
        {
            Clipboard.Clear();
            while (!Clipboard.ContainsText())
                Thread.Sleep(90);
        }
    }
