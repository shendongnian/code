    public class adsClientEntry
    {
        public DateTime EntryTime;
        public double BigMotorVelocity;
        public double SmallMotorVelocity;
    }
    private void Form1_Load(object sender, System.EventArgs e)
    {
        CreateFile();
    }
    public void CreateFile()
    {
        string path = YourFileName.Text + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        if (!System.IO.File.Exists(path))
        {
            // Create file if no Exists
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(string.Format("{0},{1},{2}", "Time", "Big Motor Actual Velocity", "Small Motor Actual Velocity"));          
            }
        }
    }
    private void AppendLog(adsClientEntry thisEntry)
    {
        string path = YourFileName.Text + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(string.Format(
                "{0},{1},{2}", 
                thisEntry.EntryTime.ToString("hh.mm.ss.ffffff"), 
                thisEntry.BigMotorVelocity.ToString(),
                thisEntry.SmallMotorVelocity.ToString()
                ));
        }
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        adsClientEntry thisEntry = new adsClientEntry();
        thisEntry.EntryTime = DateTime.Now();
        thisEntry.BigMotorVelocity = adsClient.ReadAny(hActVel, typeof(double));
        thisEntry.SmallMotorVelocity = adsClient.ReadAny(hSActVel, typeof(double));
        AppendLog(thisEntry);
        
   }
