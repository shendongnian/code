        public bool IsMouseOver
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get { return this.ReadFlag(CoreFlags.IsMouseOverCache); }
        }
