    //put a class level variable
    static object _padlock = new object();
    var tasks = new List<Task>();
    for (int i = 0; i < SingleR_mustBeWorkedUp._number_of_Requestes; i++)
    {
        var task = new Task(() =>
           {
               Random myRnd = new Random(SingleR_mustBeWorkedUp._num_path);
               while (true)
               {
                  int k = myRnd.Next(start, end);
                  if (CanRequestBePutted(timeLineR, k, SingleR_mustBeWorkedUp._time_service, start + end) == true)
                  {
                       lock(_padlock)
                          SingleR_mustBeWorkedUp.placement[i] = k;
                       break;
                  }
                }
           });
         task.Start();
         tasks.Add(task);
    } 
    Task.WaitAll(tasks.ToArray());
