    if (f1.IsHandleCreated && !f1.IsDisposed)
    {
       Thread.Sleep(1000);
       f1.Invoke(new Action(() => myData.Add("Cpu Temeprature --- " + sensor.Value.ToString())));
    }
