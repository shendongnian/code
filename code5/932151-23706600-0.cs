       class Consumer
       {
          List<int> _ids = new List<int>();
          Timer producer_timer = new Timer();
    
          public Consumer()
          {
             producer_timer.Elapsed += ProducerStopped;
             producer_timer.AutoReset = false;
          }
    
          public void OnConsumeId(int newId)
          {
             lock (_ids)
             {
                _ids.Add(newId);
                producer_timer.Interval = 5000;
                producer_timer.Start();
             }
          }
    
          public void ProducerStopped(object o, ElapsedEventArgs e)
          {
             // Do job here.
          }
       }
