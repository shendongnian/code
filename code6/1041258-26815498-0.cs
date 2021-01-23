    namespace DurationOfOverlappingTimePeriods
    {
        class Program
        {
            static void Main(string[] args)
            {
                TimeSpan taskAStart = new TimeSpan(6, 0, 0);
                TimeSpan taskAEnd = new TimeSpan(8, 0, 0);
                Tuple<TimeSpan, TimeSpan> taskATimes = GetTaskDurations(taskAStart, taskAEnd);
                Console.WriteLine("A (day): {0}", taskATimes.Item1);
                Console.WriteLine("A (night): {0}", taskATimes.Item2);
                Console.WriteLine();
    
                TimeSpan taskBStart = new TimeSpan(10, 0, 0);
                TimeSpan taskBEnd = new TimeSpan(12, 0, 0);
                Tuple<TimeSpan, TimeSpan> taskBTimes = GetTaskDurations(taskBStart, taskBEnd);
                Console.WriteLine("B (day): {0}", taskBTimes.Item1);
                Console.WriteLine("B (night): {0}", taskBTimes.Item2);
                Console.WriteLine();
    
                TimeSpan taskCStart = new TimeSpan(19, 0, 0);
                TimeSpan taskCEnd = new TimeSpan(21, 0, 0);
                Tuple<TimeSpan, TimeSpan> taskCTimes = GetTaskDurations(taskCStart, taskCEnd);
                Console.WriteLine("C (day): {0}", taskCTimes.Item1);
                Console.WriteLine("C (night): {0}", taskCTimes.Item2);
                Console.WriteLine();
    
                TimeSpan taskDStart = new TimeSpan(23, 0, 0);
                TimeSpan taskDEnd = new TimeSpan(1, 0, 0);
                Tuple<TimeSpan, TimeSpan> taskDTimes = GetTaskDurations(taskDStart, taskDEnd);
                Console.WriteLine("D (day): {0}", taskDTimes.Item1);
                Console.WriteLine("D (night): {0}", taskDTimes.Item2);
                Console.WriteLine();
    
                TimeSpan taskEStart = new TimeSpan(6, 0, 0);
                TimeSpan taskEEnd = new TimeSpan(21, 0, 0);
                Tuple<TimeSpan, TimeSpan> taskETimes = GetTaskDurations(taskEStart, taskEEnd);
                Console.WriteLine("E (day): {0}", taskETimes.Item1);
                Console.WriteLine("E (night): {0}", taskETimes.Item2);
                Console.WriteLine();
                       
            }
    
            static Tuple<TimeSpan, TimeSpan> GetTaskDurations(
                TimeSpan taskStartTime,
                TimeSpan taskEndTime)
            {
                DateTime daytimeStart = DateTime.Today.Add(new TimeSpan(7, 0, 0));
                DateTime daytimeEnd = DateTime.Today.Add(new TimeSpan(20, 0, 0));
                Range daytimeRange = new Range(daytimeStart, daytimeEnd);
    
                if (taskEndTime < taskStartTime)
                    taskEndTime = taskEndTime + TimeSpan.FromDays(1);
    
                DateTime taskStart = DateTime.Today.Add(taskStartTime);
                DateTime taskEnd = DateTime.Today.Add(taskEndTime);
                Range taskRange = new Range(taskStart, taskEnd);
    
                TimeSpan daytimeTaskDuration = daytimeRange.IntersectionDuration(taskRange);
                TimeSpan nighttimeTaskDuration = taskRange.Duration() - daytimeTaskDuration;
    
                return new Tuple<TimeSpan, TimeSpan>(daytimeTaskDuration, nighttimeTaskDuration);
            }
        }
    
        class Range
        {
            public Range()
            {
            }
    
            public Range(DateTime start, DateTime End)
            {
                this.Start = start;
                this.End = End;
            }
    
            DateTime Start { get; set; }
            DateTime End { get; set; }
    
            public TimeSpan IntersectionDuration(Range otherRange)
            {
                Range intersection = new Range();
                intersection.Start = this.Start < otherRange.Start ? otherRange.Start : this.Start;
                intersection.End = this.End < otherRange.End ? this.End : otherRange.End;
                if (intersection.Start >= intersection.End)
                    return new TimeSpan(0);
                else
                    return intersection.End - intersection.Start;
            }
    
            public TimeSpan Duration()
            {
                return this.End - this.Start;
            }
        }
    }
