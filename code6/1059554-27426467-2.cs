    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TimerExample
    {
        public class MoveTimer : System.Timers.Timer
        {
            public event EventHandler OnPerformMoveEvent = delegate { };
    
            public event EventHandler OnMovesCompletedEvent = delegate { };
    
            public MoveTimer()
            {
                Initialize(new TimeSpan(), 0);
            }
    
            public MoveTimer(TimeSpan wait, int moves)
            {
                this.Initialize(wait, moves);
            }
    
            private int _i;
    
            private int _totalmoves;
            public int Moves
            {
                get { return this._totalmoves; }
                set { this._totalmoves = value; }
            }
    
            private TimeSpan _wait;
            public TimeSpan Wait
            {
                get { return this._wait; }
                set { this._wait = value; }
            }
    
            private System.Timers.Timer _timer;
    
            private void Initialize(TimeSpan wait, int moves)
            {
                this._totalmoves = moves;
                this._wait = wait;
                this._timer = new System.Timers.Timer();
            }
    
            private void BindComponents()
            {
                this._timer.Elapsed += _timer_Elapsed;
            }
    
            private void UnBindComponents()
            {
                this._timer.Elapsed -= _timer_Elapsed;
            }
    
            public void StartTimer()
            {
                this._timer.Enabled = true;
            }
    
            public void StopTimer()
            {
                this._timer.Enabled = false;
            }
    
            void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                this._i++;
    
                if (this.OnPerformMoveEvent != null)
                    this.OnPerformMoveEvent(this, EventArgs.Empty);
    
                if (this._i == this._totalmoves)
                {
                    this._timer.Stop();
                    this.UnBindComponents();
                    this.Dispose();
    
                    if (this.OnMovesCompletedEvent != null)
                        this.OnMovesCompletedEvent (this, EventArgs.Empty);
                }
            }
        }
    }
