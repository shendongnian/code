    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {//the real console app
            //test the strange trigger class
            trigger.Trigger += trigger_Trigger;
            trigger t = new trigger();
            trigger a = new trigger();
            for (int x = 0; x <= 9; x++)
            {
                t++;
                a++;
            }
            Console.ReadLine();
        }
        static void trigger_Trigger(object sender, TriggerEventArgs e)
        {
            Console.WriteLine("once");
        }
    }
    public class trigger
    {
        static int timer = 0;
        //standard event pattern  (static style)
        public static event EventHandler<TriggerEventArgs> Trigger;
        static void onTrigger(object sender, TriggerEventArgs e) { if (Trigger != null)Trigger    (sender, e); }
        //overload the ++ operator
        public static trigger operator ++ (trigger t)
        {
            trigger.ops_main();//yeah.. i know this is kinda strange
            //but so is the question
            return t;
        }
        public static void ops_main()// <--- no args?
        {//not a console app-- main used cause op used it
            if (timer == 0) onTrigger(new object(), new TriggerEventArgs());
            /*
            else
               istriggered=false; 
            */
            timer++;//happens no matter what
            //increment your life away
        }
    }
    public class TriggerEventArgs : EventArgs
    {
      //what ever you could possibly need and more 
    }   
    
    
    }
