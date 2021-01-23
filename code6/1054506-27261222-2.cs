        public void Add(T item)
        {
            if (!_order.ContainsKey(item))
            {
                _order[item] = _order.Count;
            }
            _inner.Add(item);
            _inner.Sort(new OrderComparer(_order));
        }
