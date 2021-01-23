        public void Focus()
        {
			// normal focus will not work
            User32.SetFocus(_threadformhandle);
        }
        public void Close()
        {
            // Setting the Form.DialogResult will terminate the message loop
            Browser.DialogResult = DialogResult.Cancel; // or whatever
        }
