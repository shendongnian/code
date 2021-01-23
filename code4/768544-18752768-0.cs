    public static void DrawPulseData(byte[] data, ZedGraphControl zgc, int count, int tickStart)
    {
        double now = Environment.TickCount / 1000.0;
        if (count != 0)
        {
            double span = (now - tickStart);
    
            double inverseRate = span / count;
            for (int i = 0; i < count; i++)
            {
                list.add(tickStart + ((i+1) * inverseRate), data[i]);
            }
            Scale xScale = zgc.GraphPane.XAxis.Scale;
        }
        xScale.Max = now;
        xScale.Min = now - 30.0;
        PulseControl.AxisChange();
        PulseControl.Invalidate();
    }
