        private async void Form1_Load(object sender, EventArgs e)
    {
        await TaskProcessor();
    }
    
    async Task TaskProcessor()
    {
    
       DateTime end = DateTime.Now.AddHours(4);
        while (end > DateTime.Now)
        {
            for (byte i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        await Test1();
                        break;
                    case 1:
                        await Task.WhenAll(Test1(), Test2());
                        break;
                    case 2:
    
                        await Task.WhenAll(Test1(), Test2(), Test3());
                        break;
                    case 3:
    
                        await Task.WhenAll(Test1(), Test2(), Test3());
                        break;
                }
            }
        }
    }
    
    static async Task Test1()
    {
        int[] elevIds = new int[] { 4440, 4441, 4442 };
        IElevation[] elevs = new IElevation[3];
    
        elevs = await Task.WhenAll(Enumerable.Range(0, elevs.Length).Select(i => AlumCloudPlans.Manager.GetElevationAsync(elevIds[i])));
    
        using (var pdf = await AlumCloudPlans.Manager.RollUpProjectImageAsync(new Guid("da91dc34-fa29-4abd-bcc0-d04408310e3e"), elevs, true))
        {
            //using (var ms = new MemoryStream()) { pdf.Save(ms, false); }
        }
    }
    static async Task Test2()
    {
        int[] elevIds = new int[] { 4430, 4431 };
        IElevation[] elevs = new IElevation[2];
    
        elevs = await Task.WhenAll(Enumerable.Range(0, elevs.Length).Select(i => AlumCloudPlans.Manager.GetElevationAsync(elevIds[i])));
    
        using (var pdf = await AlumCloudPlans.Manager.RollUpProjectImageAsync(new Guid("da91dc34-fa29-4abd-bcc0-d04408310e3e"), elevs, true))
        {
            // using (var ms = new MemoryStream()) { pdf.Save(ms, false); }
        }
    }
    static async Task Test3()
    {
        int[] elevIds = new int[] { 4427 };
        IElevation[] elevs = new IElevation[1];
    
        elevs = await Task.WhenAll(Enumerable.Range(0, elevs.Length).Select(i => AlumCloudPlans.Manager.GetElevationAsync(elevIds[i])));
    
        using (var pdf = await AlumCloudPlans.Manager.RollUpProjectImageAsync(new Guid("da91dc34-fa29-4abd-bcc0-d04408310e3e"), elevs, true))
        {
            // using (var ms = new MemoryStream()) { pdf.Save(ms, false); }
        }
    }
