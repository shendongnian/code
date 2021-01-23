    var myObjectList = new List<myObject>();
    myObjectList = PopulateList();
    var options = new ParallelOptions { MaxDegreeOfParallelism = 20};
                Parallel.ForEach(myObjectList, options,
                                     (myObject) =>
                                          {
                                               //Do Work
                                               //On Complete Fire an event
                                               if (UpdateProgressEvent != null)
                                               {
                                                      UpdateProgressEvent (null, new UpdateProgressEventArgs(Something));
                                               }
                                           });
