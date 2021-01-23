    float energy = (float)Math.Sqrt(listOfSquaredSegment.Sum());
    for (int i = 0; i < fmainBuffer.Length; i += (int)window)
    {
         listaudio.Add((float)(count / ((float)8000 / (float)window)) / 5, fmainBuffer[i], energy > 4 ? 2.0 : 1.0);
         count++;
    }
    myCurveAudio = zgc.MasterPane.PaneList[1].AddCurve(null, listaudio, Color.Lime, SymbolType.None);
    Fill fill = new Fill(Color.Lime, Color.Red);
    fill.RangeMin = 1;
    fill.RangeMax = 2;
    fill.Type = FillType.GradientByZ;
    myCurveAudio.Line.GradientFill = fill;
