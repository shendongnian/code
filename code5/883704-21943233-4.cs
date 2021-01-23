    private delegate void InvokeAction();
            private void DoUI(InvokeAction call)
            {
                if (IsDisposed)
                {
                    return;
                }
                if (InvokeRequired)
                {
                    try
                    {
                        Invoke(call);
                    }
                    catch (InvalidOperationException)
                    {
                        //Alert?
                    }
                }
                else
                {
                    call();
                }
            }
