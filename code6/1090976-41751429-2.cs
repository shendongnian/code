        public async Task<Page> PopAllModals()
        {
            Page root = null;
            if (_navigation.ModalStack.Count() == 0)
                return null;
            for (var i = 0; i <= _navigation.ModalStack.Count(); i++)
            {
                root = await _navigation.PopModalAsync(false);
            }
            return root;
        }
