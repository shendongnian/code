        [TestMethod]
        public void CustomEventWithRx()
        {
            var sx =
             Observable.FromEvent(
                 new Func<Action<Tuple<IBoundItem, IEnumerable<string>>>, BoundItemUpdatedHandler<IBoundItem>>(
                     source => new BoundItemUpdatedHandler<IBoundItem>((s, e) => source(Tuple.Create(s, e)))),
                 add => this.CustomHandler += add,
                 rem => this.CustomHandler -= rem);
            sx.Select((item,index) => new { item,index}).Subscribe(next => Trace.WriteLine(next.index));
            OnCustomHandler(null, null);
        }
        public event BoundItemUpdatedHandler<IBoundItem> CustomHandler;
        protected virtual void OnCustomHandler(IBoundItem bounditem, IEnumerable<string> properties)
        {
            BoundItemUpdatedHandler<IBoundItem> handler = CustomHandler;
            if (handler != null) handler(bounditem, properties);
        }
        public delegate void BoundItemUpdatedHandler<T>(T boundItem, IEnumerable<string> properties) where T : IBoundItem;
