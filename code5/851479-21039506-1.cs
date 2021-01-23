    var subscription
        = m_BufferBlock
        .AsObservable()
        .Synchronize()
        .Where(InValue => InValue.Region == Region)
        .Do(W => logger.Debug("Side Effect => " + W.ToString())) 
        .Window(TimeSpan.FromMilliseconds(10000))
        .Select((window, index) => Tuple.Create(window,index))
        .SubscribeOn(Scheduler.Default)
        .Subscribe(window =>
            {
                window.Item1
                    .ToList()
                    .SubscribeOn(Scheduler.Default)
                    .Subscribe(workItems =>
                        {
                            foreach (WorkItem W in workItems)
                            {
                                // Some work items do not reach this line
                                logger.Debug("Came inside window " + window.Item2 + " and subscriber => " + W);
                            }
                            if (workItems.Count > 0)
                            {
                                ProcessWorkItems(workItems.ToList<WorkItem>());
                            }
                        });
            });
