        private bool _subscribed = false;
        SubscribeToOnGameListEvent();
        backend.GetGameList();
        private void SubscribeToOnGameListEvent()
        {
            if (!_subscribed)
            {
                backend.OnGameList += ProcessGameList;
                _subscribed = true;
            }
        }
