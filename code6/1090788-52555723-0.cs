        private Task _debounceTask = Task.CompletedTask;
        private volatile Action _debounceAction;
        /// <summary>
        /// Debounces anything passed through this 
        /// function to happen at most every three seconds
        /// </summary>
        /// <param name="act">An action to run</param>
        private async void DebounceAction(Action act)
        {
            _debounceAction = act;
            await _debounceTask;
            if (_debounceAction == act)
            {
                _debounceTask = Task.Delay(3000);
                act();
            }
        }
