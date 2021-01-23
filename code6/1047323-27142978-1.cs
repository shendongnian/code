            set {
                if (value != base.Text) { // Gotcha!
                    base.Text = value;
                    if (IsHandleCreated) {
                        // clear the modified flag
                        SendMessage(NativeMethods.EM_SETMODIFY, 0, 0);
                    }
                }
            }
