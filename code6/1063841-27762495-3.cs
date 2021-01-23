        private void RaiseSomeEventOccured()
        {
            Action handler = SomeEventOccured;
            if (handler != null)
            {
                var parallelOption = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
                Parallel.Invoke(parallelOption, Array.ConvertAll(handler.GetInvocationList(), ConvertToAction));
                handler();
            }
        }
        private Action ConvertToAction(Delegate del)
        {
            return (Action)del;
        }
