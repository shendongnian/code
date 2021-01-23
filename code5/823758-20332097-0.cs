            public new bool CheckBoxes
            {
                get
                {
                    return base.CheckBoxes;
                }
                set
                {
                    if (base.CheckBoxes == false)
                    {
                        base.CheckBoxes = true;
    
                        IntPtr handle = SendMessage(this.Handle, TVM_GETIMAGELIST, new
                        IntPtr(TVSIL_STATE), IntPtr.Zero);
                            if (handle != IntPtr.Zero)
                                _checkboxImageList = handle;
                    }
                }
            }
