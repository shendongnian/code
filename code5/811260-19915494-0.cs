    public static async Task makeMusic(TimeSpan timespan)
    {
        for (int i = 0; i < 5; i++)
        {
            //this assumes you can remove the parameters from this method
            playMyAudioFile(); 
            await Task.Delay(timespan);
        }
        MessageBox.Show("All done!");
    }
