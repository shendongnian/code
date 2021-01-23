    public class ResizingPanelController
    {
        public Panel PanelControl { get; private set; }
        public ResizingPanelController()
        {
            this.PanelControl = new Panel();
            // demo - in order to see the panel
            this.PanelControl.BackColor = System.Drawing.Color.LightBlue;
        }
        public void ResizeControl(int delta)
        {
            var y = this.PanelControl.Size.Height;
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                var x = this.PanelControl.Size.Width;
                // do we need to increase or decrease
                var up = delta > 0;
                // set condition end regarding resize direction (make x bigger or smaller)
                var end = up ? x + delta : x - Math.Abs(delta);
                // evaluate condition regarding resize direction
                Func<int, int, bool> conditionIsMet = (value, limit) => up ? value < limit : value > limit;
                while (conditionIsMet(x, end))
                {
                    // increase or decrease x regarding resize direction
                    x = up ? x + 1 : x - 1;
                    this.PanelControl.Size = new Size(x, y);
                    System.Threading.Thread.Sleep(10);
                    // repaint controls
                    this.PanelControl.Refresh();
                }
            }, new System.Threading.CancellationToken(), TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
