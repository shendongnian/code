        public string Process()
        {
            foreach(T record in this.Record)
            {
                string validation = record.Validate();
                // Do something with validation
            }
        }
