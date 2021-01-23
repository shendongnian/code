    public void update(string user_worker)
    {
      System.Timers.Timer timer = new System.Timers.Timer(60000);
      timer.Elapsed += (sender, e) =>
      {
        try
        {
          //query the miner for summary and gpucount information
          String SummaryQuery = QueryMiner("summary");
          String gpuNum = FindKey(QueryMiner("gpucount"), "Count");
          //String PoolQuery = QueryMiner("pools");
          int numgpus = Convert.ToInt32(gpuNum);
          //Array of strings to hold each gpu query
          String[] gpuQueries = new String[numgpus];
          //add the GPU queries into the array
          for (int i = 0; i < numgpus; i++)
              gpuQueries[i] = QueryMiner("gpu|" + i);
          //now add information specific to each gpu to a list
          List<string> gpuList = new List<string>();
          for (int i = 0; i + 1 <= gpuQueries.Length; i++)
          {
              gpuList.Add(FindKey(gpuQueries[i], "Temperature"));
              gpuList.Add(FindKey(gpuQueries[i], "MHS 5s"));
          }
          //set all the values that we have gotten from the queries
          this.worker_user_name = user_worker;
          this.hashrate = FindKey(SummaryQuery, "MHS av");
          this.accepted = FindKey(SummaryQuery, "Accepted");
          this.rejected = FindKey(SummaryQuery, "Rejected");
          this.hw_errors = FindKey(SummaryQuery, "Hardware Errors");
          this.num_gpu = gpuNum;
          this.gpus = gpuList.ToArray();
          //create JSON from the workerUpdate object
          string JSON = JsonConvert.SerializeObject(this);
          //send to website
          HttpPutRequest(JSON);
        }
        catch (Exception ex)
        {
            // handle exception here
        }
      };
     timer.Start();
    }
