     public TextBox CurrentControlInFocus
        {
            get { return _inFocusControl; }
            set
            {
                if (_inFocusControl != null && _inFocusControl != value)
                {
                    _inFocusControl.BackColor = DefaultColor;
                 
                }
                if (value == _inFocusControl) return;
                _inFocusControl = value;
                if (_inFocusControl != null)
                {
                    _inFocusControl.BackColor = FocusColor;
                    #region Important block
                    var f = Application.OpenForms[Name] ?? Singleton;
                    // just making sure both handles are created before using an invoke
                    if (Handle != IntPtr.Zero && _inFocusControl.Handle != IntPtr.Zero)
                        //call the invoke on the textbox control
                        _inFocusControl.BeginInvoke((MethodInvoker) (() => { 
                              f.Show(); //show the form 
                              // bring it to front
                              // it also should raise the event Activated 
                              f.Activate(); 
                        }));
                    #endregion
                  
                }
            }
        }
