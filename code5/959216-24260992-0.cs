        public event Action Event;
        public void Trigger()
        {
            if (Event != null)
            {
                var delegates = Event.GetInvocationList();
                Parallel.ForEach(delegates, d => d.DynamicInvoke());
            }
        }
