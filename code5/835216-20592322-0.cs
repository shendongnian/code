    private void DrawIt()
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
               50, 50, 150, 150);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
            this.Update();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawIt();
            base.OnPaint(e);
            
        }
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            //DrawIt();
        }
