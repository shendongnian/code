    var tasks = new List<Task>();
    for (int i = 0; i < SingleR_mustBeWorkedUp._number_of_Requestes; i++)
    {
        tasks.Add(new Task(() =>
           {
               Random myRnd = new Random(SingleR_mustBeWorkedUp._num_path);
               while (true)
               {
                  int k = myRnd.Next(start, end);
                  if (CanRequestBePutted(timeLineR, k, SingleR_mustBeWorkedUp._time_service, start + end) == true)
                  {
                       SingleR_mustBeWorkedUp.placement[i] = k;
                       break;
                  }
                }
           }));
    } 
    Task.WaitAll(tasks.ToArray());
