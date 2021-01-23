    private void PlayNumbers()
    {
        foreach (var item in numbers)
        {
            try
            {
                vr.PlayTTS(item.ToString()); // will be 0,1,2,...9
                Thread.Sleep(2000);
            }
            ...
        }
        terminate.set();
    }
