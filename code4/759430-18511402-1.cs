     public ApplicationScreenBase()
            {
                this.Loaded +=ApplicationScreenBase_Loaded;
                this.Unloaded += ApplicationScreenBase_Unloaded;
                this.Activated += ApplicationScreenBase_Activated;
                this.Deactivated += ApplicationScreenBase_Deactivated;
            }
    
            void ApplicationScreenBase_Deactivated(object sender, EventArgs e)
            {
                AppMessenger.Unregister(this, OnMessageToApp);
            }
    
            void ApplicationScreenBase_Activated(object sender, EventArgs e)
            {
                AppMessenger.Register(this, OnMessageToApp);
            }
