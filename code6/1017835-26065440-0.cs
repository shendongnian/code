    private const string TriggerFile = @"C:\TriggerData\trigger.txt";
    private DateTime _triggerDate;
    if (!File.Exists(TriggerFile))
    {
        using (StreamWriter sw = File.CreateText(TriggerFile))
        {
            sw.WriteLine(DateTime.Now.AddHours(24));
        }
    }
    using (StreamReader sr = File.OpenText(TriggerFile))
    {
        _triggerDate = DateTime.Parse(sr.ReadToEnd());
    }
    while (true)
    {
        if (DateTime.Now >= _triggerDate)
        {
            MessageBox.Show(@"Alert!");
            using (StreamWriter sw = File.CreateText(TriggerFile))
            {
                sw.WriteLine(DateTime.Now.AddHours(24));
                _triggerDate = DateTime.Now.AddHours(24);
            }
        }
        System.Threading.Thread.Sleep(60000*5); // Sleep for 5 minutes
    }
