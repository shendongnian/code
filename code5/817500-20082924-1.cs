    public class Foo
    {
        public void SomeEventHandler(object sender, EventArgs args)
        {
            EventThrottler.Default.Run(async () =>
            {
                await Task.Delay(1000);
                //do other stuff
            });
        }
    }
