    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TimerExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create move timer that will trigger 15 times, once every 30 seconds.
                MoveTimer moveTimer = new MoveTimer(new TimeSpan(0, 0, 30), 15);
    
                //Substribe to the move timer events
                moveTimer.OnPerformMoveEvent += moveTimer_OnPerformMoveEvent;
                moveTimer.OnMovesCompletedEvent += moveTimer_OnMovesCompletedEvent;
    
                //Start the timer
                moveTimer.StartTimer();
    
                //What happens in between the moves performed?
            }
    
            static void moveTimer_OnMovesCompletedEvent(object sender, EventArgs e)
            {
                //All the moves have been performed, what would you like to happen? Eg. Beep or tell the user.
            }
    
            static void moveTimer_OnPerformMoveEvent(object sender, EventArgs e)
            {
                //Timer has lapsed, what needs to be done when a move is requested?
            }
        }
    }
