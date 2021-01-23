    public class timer
    {
    public event EventHandler TimerTick;
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        if (TimerTick != null)
            TimerTick(this, null);
    }
