    public static void Main(string[] args)
    {
        // wait 5 secs
        System.Threading.Thread.Sleep(5000);
        // go to MSPaint and wait
        System.Windows.Forms.SendKeys.SendWait("^v");
    }
