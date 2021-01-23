    public async Task ReadCodes()
    {
        foreach (var line in lines)
        {
            await Task.Run(() =>
            {
                //foo code
                {
                    //some other codes
                    SetText("doing something");
                }
            });
        }
        //some other foo
    }
