    public class LongClick
    {
        public static void Attach(Control Control, EventHandler Handler)
        {
            var LC = new LongClick { Control = Control, Handler = Handler };
            Control.MouseDown += LC.ControlOnMouseDown;
            Control.MouseMove += LC.ControlOnMouseMove;
            Control.MouseUp += LC.ControlOnMouseUp;
        }
        private Control Control;
        public EventHandler Handler;
        private DateTime? MDS;
        private void ControlOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) MDS = DateTime.Now;
        }
        private void ControlOnMouseMove(object sender, MouseEventArgs e)
        {
            if (MDS == null) return;
            if (e.X < 0) MDS = null;
            if (e.X > Control.Width) MDS = null;
            if (e.Y < 0) MDS = null;
            if (e.Y > Control.Height) MDS = null;
        }
        private void ControlOnMouseUp(object sender, MouseEventArgs e)
        {
            if (MDS == null) return;
            if (e.Button != MouseButtons.Left) return;
            var TimePassed = DateTime.Now.Subtract(MDS.Value);
            MDS = null;
            if (TimePassed.TotalSeconds < 1) return;
            if (Handler == null) return;
            Handler(Control, EventArgs.Empty);
        }
    }
