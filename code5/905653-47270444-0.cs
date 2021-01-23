     private static void TimerThread(object obj)
        {
            int delay = (int)obj;
            while (true)
            {
                takePhotos = true;
                Thread.Sleep(delay);
            }
        }
    static void Main(string[] args)
        {
            WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Console.WriteLine("Press Any Key To Capture Photo !");
            Console.ReadKey();
            Device = new VideoCaptureDevice(WebcamColl[0].MonikerString);
            Device.NewFrame += Device_NewFrame;
            Device.Start();
            Thread timer=new Thread(TimerThread);
             timer.Start(60000);
            Console.ReadLine();
        }
        static void Device_NewFrame(object sender, NewFrameEventArgs e)
        {
           if(!takePhotos)return;
            Bitmap Bmp = (Bitmap)e.Frame.Clone();
            Bmp.Save("D:\\Foo\\Bar.png");
            takePhotos=false;
            Console.WriteLine("Snapshot Saved.");
            /*
            Console.WriteLine("Stopping ...");
            Device.SignalToStop();
            Console.WriteLine("Stopped .");
            */
        }
