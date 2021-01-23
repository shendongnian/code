       class Program
       {
          static private CustomTimerClass _customTimer;
          static private float _varIWantToChange = 1;
          static public void Main()
          {
             _customTimer = new CustomTimerClass(changeVar);
          }
    
          static public void changeVar(object sender, ElapsedEventArgs e)
          {
             _varIWantToChange++;
             Console.WriteLine(_varIWantToChange);
          }
       }
    
       public class CustomTimerClass
       {
          private System.Timers.Timer _timer;
          public CustomTimerClass()
          {
          }
    
          public CustomTimerClass(ElapsedEventHandler e)
          {
             _timer = new Timer();
             _timer.Elapsed += e;  //i can't pass varIwantToChange as a parameter here
             _timer.Elapsed += _timer_Elapsed;
          }
    
          public void _timer_Elapsed(object sender, ElapsedEventArgs e)
          {
             // Do timer stuff
          }
       }
