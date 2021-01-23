    private static System.Timers.Timer aTimer;
    private static bool blinkFlag;
    private Label label;
    
    private void abilitaAltroToken(int indiceRiga,Grid grid)
    {
            UIElement element = grid.Children[indiceRiga];
            label = (Label)element;
            element = grid.Children[++indiceRiga];
            TextBox textBox = (TextBox)element;
            textBox.Background = Brushes.Blue;
            label.Background = Brushes.Blue;
        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        // Set the Interval to 1 seconds (1000 milliseconds).
        aTimer.Interval = 1000;
        aTimer.Enabled = true;
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
       label.Background = (blinkFlag?Brushes.Blue:Brushes.White);
       blinkFlag=!blinkFlag;
       aTimer.Interval = 1000;
       aTimer.Enabled = true;
    }
