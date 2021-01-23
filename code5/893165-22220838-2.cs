    LineItem myCurveAudio;
    LineItem myCurveAudio2;
    PointPairList list1 = new PointPairList();
    PointPairList list2 = new PointPairList();
    double lastAddedHighEnergy = double.NaN;
    double lastAddedLowEnergy = double.NaN;
    while (true)
    {
    	for (int i = 0; i < fmainBuffer.Length; i++)
    	{
    		float segmentSquare = fmainBuffer[i] * fmainBuffer[i];
    		listOfSquaredSegment.Add(segmentSquare);
    	}
    	float energy = (float)Math.Sqrt(listOfSquaredSegment.Sum());
    	if (energy < 4)
    	{
    		for (int i = 0; i < read; i += (int)window)
    		{
    			lastAddedLowEnergy = (double)(count / ((double)read / (double)window));
    			if (lastAddedHighEnergy != double.NaN)
    			{
    				list1.Add(lastAddedHighEnergy + ((lastAddedLowEnergy - lastAddedHighEnergy) / 2.0), double.NaN);
    				lastAddedHighEnergy = double.NaN;
    			}
    
    			list1.Add(lastAddedLowEnergy, fmainBuffer[i]);
    			count++;
    		}
    	}
    	else
    	{
    		for (int i = 0; i < read; i += (int)window)
    		{
    			lastAddedHighEnergy = (double)(count / ((double)read / (double)window));
    			if (lastAddedLowEnergy != double.NaN)
    			{
    				list2.Add(lastAddedLowEnergy + ((lastAddedHighEnergy - lastAddedLowEnergy) / 2.0), double.NaN);
    				lastAddedLowEnergy = double.NaN;
    			}
      			list2.Add(lastAddedHighEnergy, fmainBuffer[i]);
    			count++;
    		}
    	}
    }
    zgc.MasterPane.PaneList[1].XAxis.Scale.MaxAuto = true;
    zgc.MasterPane.PaneList[1].XAxis.Scale.MinAuto = true;
    zgc.MasterPane.PaneList[1].XAxis.Type = AxisType.Linear;
    zgc.MasterPane.PaneList[1].XAxis.Scale.Format = "";
    zgc.MasterPane.PaneList[1].XAxis.Scale.Min = 0;
    myCurveAudio = zgc.MasterPane.PaneList[1].AddCurve(null, list1, Color.Lime, SymbolType.None);
    myCurveAudio2 = zgc.MasterPane.PaneList[1].AddCurve(null, list2, Color.Red, SymbolType.None);
