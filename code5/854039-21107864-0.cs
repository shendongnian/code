        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                RemoveEventHandler();
            }
        }
        private void RemoveEventHandler()
        {
            if (!_subscribed)
                return;
            var source = (TSource) _sourceReference.Target;
            if (source != null)
            {
                _sourceEventInfo.GetRemoveMethod().Invoke(source, new object[] {CreateEventHandler()});
                _subscribed = false;
            }
        }
