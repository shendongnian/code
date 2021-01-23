    static void Main(string[] args)
    {
        const bool generate = true;
        NewBookingTimer(generate);
        Console.ReadLine();
    }
    public static void NewBookingTimer(bool generate)
    {
        if (!generate) return;
        var newBookingTimer = new Timer();
        newBookingTimer.Elapsed += (sender, e) => NewBooking();
        newBookingTimer.Elapsed += (sender, e) => OldBooking();
        var random = new Random();
        int randomNumber = random.Next(0, 500);
        Console.Out.WriteLine("Random = " + randomNumber);
        newBookingTimer.Interval = randomNumber;
        newBookingTimer.Enabled = true;
    }
    public static void NewBooking()
    {
        Console.Out.WriteLine("this is NEW booking");
    }
    public static void OldBooking()
    {
        Console.Out.WriteLine("this is OLD booking");
    }
