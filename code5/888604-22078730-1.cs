    List<Task<PingReply>> pingTasks = new List<Task<PingReply>>();
            addStatus("Scanning Network");
            foreach (var ip in range)
            {
                pingTasks.Add(pingAsync(ip));
            }
            Task.WaitAll(pingTasks.ToArray());
            addStatus("Network Scan Complete");
            scanTargetDelegate d = null;
            IAsyncResult r = null;
    foreach (var pingTask in pingTasks)
            {
                if (pingTask.Result.Status.Equals(IPStatus.Success))
                {
                    d = new scanTargetDelegate(scanTarget); //do something with the ip
                    r = d.BeginInvoke(pingTask.Result.Address, null, null);
                    Interlocked.Increment(ref Global.queuedThreads);
                }
                else
                {
                    if (!ownIPs.Contains(pingTask.Result.Address))
                    {
                        failed.Add(pingTask.Result.Address);
                    }
                }
            }
            if (r != null)
            {
                WaitHandle[] waits = new WaitHandle[] { r.AsyncWaitHandle };
                WaitHandle.WaitAll(waits);
            }
