    ListResults = new DataPoint[nROIrow];
    //DataPoint TempRes = new DataPoint();
    System.Collections.ArrayList List = new System.Collections.ArrayList();
    
    for (int i = 0; i < nROIrow; i++)
    {
       DataPoint TempRes = new DataPoint();
       ...
       ListResults[i] = TempRes;
       var disp = new ...
       disp.Xpix = ListResults[i].X;
       ....
       List.Add(disp);
    }  
