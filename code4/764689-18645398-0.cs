        private bool _newResult;
        public LrgDialogBox(ref bool oldResult)
        {
            // bunch of code
            _newResult = oldResult;
            UserInput();
            oldResult = _newResult;
        }
        private void UserInput()
        {
 	        _newResult = false;
        }
