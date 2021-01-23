    List<Rectangle> plotPoints = new List<Rectangle>();
    private void button1_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader("helyforr.txt");
        double[] x = new double[3124] //there is 3124 lines in the text;
        double[] y = new double[3124];
        int scale = 10;    // I start with a scale down fastor of 10. 
               // you could also calculate it taking the size of the canvas into account..
        while (!sr.EndOfStream)
        {
            string sor = sr.ReadLine();
            sor = sor.Replace('.', ','); //swap '.' to ',' make it double
            string[] r = sor.Split(' ');
            x[0] = Convert.ToDouble(r[0]) / scale;
            y[0] = Convert.ToDouble(r[1]) / scale;
            plotPoints.Add(new Rectangle( (Int32)x[0], (Int32)y[0], 1, 1));
        }
        sr.Close();
        canvasPanel.Invalidate();
    }
