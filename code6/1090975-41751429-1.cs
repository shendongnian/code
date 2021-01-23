        public void ResetNavigationStack()
        {
            if (_navigation != null && _navigation.NavigationStack.Count() > 0)
            {
                var existingPages = _navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    _navigation.RemovePage(page);
                }
            }
        }
