        public void Add(MyTask task)
        {
            // startTimeSet
            refTime.time = task.startDt;
            var lst = startTimeSet.GetViewBetween(refTime,
                refTime).FirstOrDefault();
            if (lst == null) // no bucket found for time
            {
                lst = new SameTimeTaskList { time = task.startDt };
                startTimeSet.Add(lst);
            }
            lst.taskList.Add(task); // add task to bucket
            // endTimeSet
            refTime.time = task.endDt;
            lst = endTimeSet.GetViewBetween(refTime,
                refTime).FirstOrDefault();
            if (lst == null) // no bucket found for time
            {
                lst = new SameTimeTaskList { time = task.endDt };
                endTimeSet.Add(lst);
            }
            lst.taskList.Add(task); // add task to bucket
        }
