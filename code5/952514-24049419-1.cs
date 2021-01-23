       class Program
       {
          static private CustomTimerClass _customTimer;
          static private int _varIWantToChange = 1;
          static public void Main()
          {
             _customTimer = new CustomTimerClass(changeVar);
             while (_varIWantToChange == 1)
             {
                System.Threading.Thread.Sleep(1);
             }
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
    
          public CustomTimerClass(ElapsedEventHandler callbackMethod)
          {
             _timer = new Timer();
             _timer.Elapsed += callbackMethod;  //i can't pass varIwantToChange as a parameter here
             _timer.Elapsed += _timer_Elapsed;
             _timer.Interval = 500;
             _timer.Start();
          }
    
          public void _timer_Elapsed(object sender, ElapsedEventArgs e)
          {
             // Do timer stuff
          }
       }
