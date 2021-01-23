    using System.Windows.Forms;
    using System.Drawing;
    class AreaChart : Panel
    {
        public Padding ChartPadding { get; set; }
        public Point AxisOriginOffset { get; set; }
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        olor[][] colors { get; set; }
        string[][] texts { get; set; }
        public string[] labelsY { get; set; }  //*
        public string[] labelsX { get; set; }  //*
        Rectangle chartArea = Rectangle.Empty;
        Point axisOrigin = Point.Empty;
        public void Init()
        {
            chartArea = new Rectangle(ChartPadding.Left, ChartPadding.Top,
                        this.Width - ChartPadding.Left - ChartPadding.Right, 
                        this.Height - ChartPadding.Top - ChartPadding.Bottom);
            axisOrigin = new Point(AxisOriginOffset.X, this.Height - AxisOriginOffset.Y);
            colors = new Color[RowNum][];
            for (int r = 0; r < RowNum; r++) colors[r] = new Color[ColNum];
            texts = new string[RowNum][];
            for (int r = 0; r < RowNum; r++) texts[r] = new string[ColNum];
            labelsX = new string[ColNum];  //*
            labelsY = new string[RowNum];  //*
        }
        public AreaChart()
        {
            ChartPadding = new Padding(80, 40, 40, 40);
            AxisOriginOffset = new Point(60, 20);
            RowNum = 3;
            ColNum = 2;
            BackColor = Color.AntiqueWhite;
            Init();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DesignMode) Init();      // make the designer show the current
            if (this.DesignMode) InitDemo();  // ...sizes, colors and texts
            int x = chartArea.X;
            int y = chartArea.Y;
            SizeF tSize = e.Graphics.MeasureString("XX", this.Font, 9999);
            int th = (int)tSize.Height / 2;
            int tw = (int)tSize.Width / 2;
            int h = chartArea.Height / RowNum;
            int w = chartArea.Width / ColNum; e.Graphics.Clear(BackColor);
            e.Graphics.DrawLine(Pens.Black, axisOrigin, 
                                new Point(axisOrigin.X, chartArea.Top));
            e.Graphics.DrawLine(Pens.Black, axisOrigin, 
                                new Point( chartArea.Right, axisOrigin.Y));
            for (int r = 0; r < RowNum; r++)
                for (int c = 0; c < ColNum; c++)
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors[r][c]), 
                      x + c * w, y + r * h, w, h);
                    e.Graphics.DrawRectangle(Pens.Black, x + c * w, y + r * h, w, h);
                    e.Graphics.DrawString(texts[r][c], this.Font, Brushes.Black, 
                      x + c * w  + w / 2 - tw, y + r * h + h / 2 - th);
                }
            for (int r = 0; r < RowNum; r++)
                e.Graphics.DrawString(labelsY[r], this.Font, Brushes.Black, 
                  AxisOriginOffset.X - tw * 2, y + r * h + h / 2 - th);  //*
            for (int c = 0; c < ColNum; c++)
                e.Graphics.DrawString(labelsX[c], this.Font, Brushes.Black,
                    x + c * w + w / 2 - tw, axisOrigin.Y );             //*
            base.OnPaint(e);;
        }
        public void setColor (int row, int col, Color color)
        {
            try
            {
                colors[row][col] = color;
            } catch { throw new Exception("setColor : array index out of bounds!"); }
        }
        public void setText(int row, int col, string text)
        {
            try
            {
                texts[row][col] = text;
            } catch { throw new Exception("setText: array index out of bounds!"); }
        }
        public void setLabelX(int col, string text)      //*
        {
            try
            {
                labelsX[col] = text;
            } catch { throw new Exception("array index out of bounds!"); }
        }
        public void setLabelY(int row, string text)      //*
        {
            try
            {
                labelsY[row] = text;
            } catch { throw new Exception("array index out of bounds!"); }
        }
        public void InitDemo()
        {
            setColor(0, 0, Color.Plum);
            setColor(1, 0, Color.GreenYellow);
            setColor(2, 0, Color.Gold);
            setColor(0, 1, Color.LightSkyBlue);
            setColor(1, 1, Color.NavajoWhite);
            setColor(2, 1, Color.Pink);
            setText(0, 0, "AA");
            setText(1, 0, "BA");
            setText(2, 0, "CA");
            setText(0, 1, "AB");
            setText(1, 1, "BB");
            setText(2, 1, "BC");
            setLabelY(0, "A");     //*
            setLabelY(1, "B");     //*
            setLabelY(2, "C");     //*
            setLabelX(0, "A");     //*
            setLabelX(1, "B");     //*
        }
    }
