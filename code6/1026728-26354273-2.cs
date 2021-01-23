	// _input will be the property you have with a binding to the textbox control in the view.
	// in the canExecute part add the conditions you want to use to check if the lostfocus command will be raised
     _lostFocusCommand = new DelegateCommand<string>(
      (s) => { /* perform some action */
         MessageBox.Show("The lostfocuscommand works!");
      }, //Execute
      (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
      );
	  
