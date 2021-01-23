    public class Program
    {
    private static DateTime startTime;
    
    public static void Main(string[] args)
    {
        SystemEvents.PowerModeChanged += OnPowerModeChanged;
        Console.ReadLine();
    }
    
    public static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        if (SystemInformation.PowerStatus.PowerLineStatus.ToString() == "Offline")
        {
            this.startTime = DateTime.Now();
        }
    }
    }
