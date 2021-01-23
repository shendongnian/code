        public class ContactSensorHelper:IDisposable
        {
            
            public delegate void OnReleaseStateChanged(ContactSensorEventArgs e);
            private ContactSensorEventArgs.ReleaseState recentReleaseState;
            public void ReportStateChanged()
            {
                if (statechangedList.Count > 0)
                {
                    var e = new ContactSensorEventArgs()
                    {
                        State = recentReleaseState
                    };
                    statechangedList.ForEach(t =>
                        t.Item1.Post(o => t.Item2((ContactSensorEventArgs)o), e));
                }
            }            
            List<Tuple<AsyncOperation, OnReleaseStateChanged>> statechangedList = new List<Tuple<AsyncOperation,OnReleaseStateChanged>>();
            public event OnReleaseStateChanged ReleaseStateChanged
            {
                add
                {
                    var op = AsyncOperationManager.CreateOperation(null);
                    statechangedList.Add(Tuple.Create(op, value));                    
                }
                remove
                {
                    var toremove = statechangedList.Where(t => t.Item2 == value).ToArray();
                    foreach (var t in toremove)
                    {
                        t.Item1.OperationCompleted();
                        statechangedList.Remove(t);
                    }
                }
            }
            public void Dispose()
            {
                statechangedList.ForEach(t => t.Item1.OperationCompleted());
                statechangedList.Clear();
            }
            public class ContactSensorEventArgs : EventArgs
            {
                //......
                public ReleaseState State { get; set; }
                //......
                public enum ReleaseState
                {
                    FullReleased,
                    PartlyReleased,
                    NotReleased
                }
            }
        }
