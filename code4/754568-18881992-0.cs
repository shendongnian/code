    public sealed class AutoInvokingEvent
    {
        private AutoInvokingEvent _statuschanged;
        public event EventHandler StatusChanged
        {
            add
            {
                _statuschanged.Register(value);
            }
            remove
            {
                _statuschanged.Unregister(value);
            }
        }
        private void OnStatusChanged()
        {
            if (_statuschanged == null) return;
            _statuschanged.OnEvent(this, EventArgs.Empty);
        }
        private AutoInvokingEvent()
        {
            //basis case what doesn't allocate the event
        }
        /// <summary>
        /// Creates a new instance of the AutoInvokingEvent.
        /// </summary>
        /// <param name="statusevent">If true, the AutoInvokingEvent will generate events which can be used to inform components of its status.</param>
        public AutoInvokingEvent(bool statusevent)
        {
            if (statusevent) _statuschanged = new AutoInvokingEvent();
        }
        public void Register(Delegate value)
        {
            //mess what registers event
            OnStatusChanged();
        }
        public void Unregister(Delegate value)
        {
            //mess what unregisters event
            OnStatusChanged();
        }
        public void OnEvent(params object[] args)
        {
            //mess what calls event handlers
        }
    }
