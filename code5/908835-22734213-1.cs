            class Mode2 : State
            {
            public override void Handle(ModeContext mode)
            {
                mode.State = new Mode2();//(mode);
            }
            public Mode2()
            {
                //do something;   
            }
            #region event handlers
            public override void OnCWRotationEvent(ModeContext mode)
            {
                mode.State = new Mode3(mode);
            }
            public override void OnCCWRotationEvent(ModeContext mode)
            {
                mode.State = new Mode1(mode);
            }
            #endregion
        }
