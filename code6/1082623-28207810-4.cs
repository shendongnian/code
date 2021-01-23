        public IEnumerable<MyTask> Get(DateTime exactTime)
        {
            refTime.time = exactTime;
            // set of all tasks started before exactTime
            SortedSet<SameTimeTaskList> sSet =
               startTimeSet.GetViewBetween(minTime, refTime);
            // set of all tasks ended after exactTime
            SortedSet<SameTimeTaskList> eSet =
               endTimeSet.GetViewBetween(refTime, maxTime);
            List<MyTask> result = new List<MyTask>();
            if (sSet.Count < eSet.Count) // check smaller set for 2nd condition
            {
                foreach (var tl in sSet)
                    foreach (MyTask tsk in tl.taskList)
                        if(tsk.endDt >= exactTime) result.Add(tsk);
            }
            else // eSet is smaller
            {
                foreach (var tl in eSet)
                    foreach (MyTask tsk in tl.taskList)
                        if (tsk.startDt <= exactTime) result.Add(tsk);
            }
            return result;
        }
