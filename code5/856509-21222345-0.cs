        int paintReps = 0;
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            System.Threading.Thread.Sleep(1);
            if(paintReps++ % 500 == 0)
                Application.DoEvents();
        }
