        public override string ToString()
        {
    #IF (DEBUG)
            if ( Debugger.IsAttached )
            {
                return this.GetType().Name + ": " + this.Title; // or something else.
            }
    #ENDIF
            // The rest of your ToString implementation
        }
