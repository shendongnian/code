        /// <summary>
        /// True if running in silent display mode (ie: no UI).
        /// </summary>
        public virtual bool RunningSilent
        {
            get
            {
                return (DisplayMode != Display.Full && DisplayMode != Display.Passive);
            }
        }
        protected override void Run()
        {
            if (RunningSilent)
            {
                 Log("Running without UI");
                 LaunchAction requestedAction = Command.Action;
                 //... this is an async call, so handle it accordingly.
                 Engine.Plan(requestedAction);
                 //... followed by Engine.Apply();
            }
            else
            {
                Log("Showing UI window");
                //.. Run your Managed UI
            }
        }
