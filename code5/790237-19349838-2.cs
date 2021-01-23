     public static void Main(string[] args)
    {
        CounterClass sz = new CounterClass();
        KinectSensor sensor = KinectSensor.KinectSensors[0];
        Vector4 gravity;
        sz.StringTemp = new StringBuilder();
        sz.Counter = 0;
        Timer timer = new Timer();
        timer.Start();
        timer.Elapsed += (sender,e) => OnTimeEvent(sender,e,cz);
        timer.Interval = 300000;
        timer.Enabled = true;
        while (sz.Counter < 7500)
        {
            gravity = sensor.AccelerometerGetCurrentReading();
            DateTime dt = DateTime.Now;
            Console.WriteLine("X: {0}\tY: {1}\tZ: {2}\t{3}.{4}", gravity.X, gravity.Y, gravity.Z, dt, dt.Millisecond);
            sz.StringTemp.AppendLine("X:" + gravity.X.ToString() + "\tY:" + gravity.Y.ToString() + "\tZ:" + gravity.Z.ToString() + "\t" + dt + "." + dt.Millisecond);
            sz.Counter++;
        }
    }
     private static void OnTimeEvent(object sender, ElapsedEventArgs e, CounterClass cz)
     {
        using(System.IO.StreamWriter sw=new System.IO.StreamWriter("myPath\\MyFileName.txt",true))
            sw.Write(sz.StringTemp);
     }
