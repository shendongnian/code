    class Input
    {
        State old;
    
        void GetInput()
        {
            State new = controller.GetState();
            if (this.old.GamePad.Buttons == GamepadButtonFlags.A && new.GamePad.Buttons == GamepadButtonFlags.A)
            {
                // Do stuff that will be called only once.
            }
            this.old = new;
        }
    }   
