    using System.Threading;
    using System.Globalization;
    void SetLocale() {
        CultureInfo ci = new CultureInfo("es-US");
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
        Console.WriteLine("CurrentCulture set: " + ci.Name);
    }
