            public string id
            {
                // having this set to id causes endless recursion
                //get { return id; }
                //use this instead
                get { return vehicalId; }
                set { this.vehicalId = id; }
            }
