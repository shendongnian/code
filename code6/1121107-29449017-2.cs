    public class LongClick
    {
        public static void Attach(Button Button, EventHandler Handler)
        {
            var LC = new LongClick {Button = Button, Handler = Handler};
            Button.MouseDown += LC.ButtonOnMouseDown;
            Button.MouseMove += LC.ButtonOnMouseMove;
            Button.MouseUp += LC.ButtonOnMouseUp;
        }
        private Button Button;
        private EventHandler Handler;
        private DateTime? MDS;
        private void ButtonOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) MDS = DateTime.Now;
        }
        private void ButtonOnMouseMove(object sender, MouseEventArgs e)
        {
            if (MDS == null) return;
            if (e.X < 0) MDS = null;
            if (e.X > Button.Width) MDS = null;
            if (e.Y < 0) MDS = null;
            if (e.Y > Button.Height) MDS = null;
        }
        private void ButtonOnMouseUp(object sender, MouseEventArgs e)
        {
            if (MDS == null) return;
            if (e.Button != MouseButtons.Left) return;
            var TimePassed = DateTime.Now.Subtract(MDS.Value);
            MDS = null;
            if (TimePassed.TotalSeconds < 1) return;
            if (Handler == null) return;
            Handler(Button, EventArgs.Empty);
        }
    }
