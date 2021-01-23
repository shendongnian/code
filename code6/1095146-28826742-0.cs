     private void OnReadTimer(object source, ElapsedEventArgs e) //check states on timer
        {
            int TagCnt = DataCtrl.TagList.Count;
            po.MaxDegreeOfParallelism = DataCtrl.TagList.Count;
            // string ss = "tags=" + TagCnt;
            //int TempID;
            Random rand = new Random();
            try
            {
                if (TagCnt != 0)
                {                    
                    ParallelLoopResult loopResult = Parallel.For(0, TagCnt - 1, po, (i, loopState) =>
                    {
                        po.CancellationToken.ThrowIfCancellationRequested();
                        int TempID = i;
                        Thread.Sleep(rand.Next(100, 200));
                        int ID = 0;
                        bool State = false;
                        long WT = 0;
                        int ParID = 0;
                        bool Save = false;                        
                        ReadStates(TempID, out ID, out State, out WT, out ParID, out Save);
                        lock (locker)
                        {
                            if (Save) WriteState(ID, State, WT, ParID);
                        }
                    });
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch (System.NullReferenceException eNullRef)
            {
                AddLog("Error:" + eNullRef);
            }
            catch (System.ArgumentOutOfRangeException e0)
            {
                AddLog("Error:" + e0);
            }
            catch (Exception e1)
            {
                //AddLog("Error while processing data: " + e1);
            }
        }
