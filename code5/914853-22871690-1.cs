        public User() {
            this._self = this; // Initialize User object with a reference to itself
        }
        [NotMapped]
        public User _self { get; set; }
