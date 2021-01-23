        private bool locked = false;
        public void Lock()
        {
            this.locked = true;
        }
        public bool Locked
        {
            get { return this.locked; }
        }
        // add same Name member as above
    }
