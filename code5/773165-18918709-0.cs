        int window;
        LineItem myCurve1;
        LineItem myCurve2;
        public void DrawWave(ZedGraphControl zgc)
        {
            NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
            WaveFileReader wavFile = new WaveFileReader(open.FileName);
            byte[] mainBuffer = new byte[wave.Length];
            float fileSize = (float)wavFile.Length / 1048576;
            if (fileSize < 2)
                window = 8;
            else if (fileSize > 2 && fileSize < 4)
                window = 16;
            else if (fileSize > 4 && fileSize < 8)
                window = 32;
            else if (fileSize > 8 && fileSize < 12)
                window = 128;
            else if (fileSize > 12 && fileSize < 20)
                window = 256;
            else if (fileSize > 20 && fileSize < 30)
                window = 512;
            else
                window = 2048;
            float[] fbuffer = new float[mainBuffer.Length / window];
            wave.Read(mainBuffer, 0, mainBuffer.Length);
            for (int i = 0; i < fbuffer.Length; i++)
            {
                fbuffer[i] = (BitConverter.ToSingle(mainBuffer, i * window));
            }
            double time = wave.TotalTime.TotalSeconds;
            GraphPane myPane = zgc.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < fbuffer.Length; i++)
            {
                list1.Add(i, fbuffer[i]);
            }
            list2.Add(0, 0);
            list2.Add(time, 0);
            if (myCurve1 != null && myCurve2 != null)
            {
                myCurve1.Clear();
                myCurve2.Clear();
            }
            myCurve1 = myPane.AddCurve(null, list1, Color.Red, SymbolType.None);
            myCurve1.IsX2Axis = true;
            myCurve2 = myPane.AddCurve(null, list2, Color.Black, SymbolType.None);
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MinAuto = true;
            zgc.AxisChange();
            zgc.Invalidate();
        }
