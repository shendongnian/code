        p_machine_job_completionTime = new int[Constants.numberMachines][];
        int counter = 0;  
        for (i = 0; i < Constants.numberMachines; i++)
        {
            p_machine_job_completionTime[i] = new int[Constants.numberJobs];
            for (j = 0; j < Constants.numberJobs; j++)
            {
                  if( counter%5 == 0)
                  {
                     p_machine_job_completionTime[i][j] = 0;
                  }
                  else
                  {
                     p_machine_job_completionTIme[i][j] = random (1,99);                         
                  }
                  counter++;
            }
        }
