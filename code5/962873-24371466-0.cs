    class ItemHaver
    {
        private int _status;
        private Item _item;
        private Dictionary<EventHandler<StatusEventArgs>, EventHandler> handlersMap = new Dictionary<EventHandler<StatusEventArgs>, EventHandler>();
        public event EventHandler<StatusEventArgs> ItemValueChanged
        {
            add
            {
                // _item.ValueChanged += value; // Wrong type
                handlersMap.Add(value, (obj, e) => value(obj, new StatusEventArgs(this._status)));
                _item.ValueChanged += handlersMap[value];
            }
            remove
            {
                _item.ValueChanged -= handlersMap[value];
            }
        }
    }
