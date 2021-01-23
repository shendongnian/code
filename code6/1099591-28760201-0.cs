    using System.Text.RegularExpressions;
    ...
    
    Regex re83 = new Regex(@"^[^.]{1,8}(\.[^.]{0,3})?$");
    DirectoryInfo directoryInfo = new DirectoryInfo("C:\\windows");
    foreach (string no83 in directoryInfo.GetDirectories("i*").Select(di => di.Name).Where(n => !re83.IsMatch(n)))
    {
        Console.WriteLine(no83);
    }
