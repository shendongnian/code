     private LongRunningTask()
      {
       autoReviewProgressValue = 0;
            if (longrunningTasks.count > 0)
            {
               foreach(Task task in longRunningTaskList)
               {
                if ((bool)Session["IsStopAutoReview"])
                    {
                        ControlVisibility(false);
                        autoReviewThread.Abort();
                    }
                   int valueToIncreament = int.Parse(Math.Round((double)(100 - autoReviewProgressValue) / (longrunningTasks.Count - longrunningTasks.IndexOf(task)), MidpointRounding.AwayFromZero).ToString());
                   
                    //Your processing of the task 
                   If( Processtask(task))
                    {
                    autoReviewProgressMessage = "Task " + longrunningTasks.IndexOf(task) + " processed sucessfull.";
                    }
                    else
                        autoReviewProgressMessage = "Task " + longrunningTasks.IndexOf(task)+ " failed to process.";
                    autoReviewProgressValue += valueToIncreament;
                }
            }
       }
