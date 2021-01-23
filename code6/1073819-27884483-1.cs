        public void StartProcessing()
        {
            try
            {
                this._Employees.AsParallel().WithCancellation(cs.Token).ForAll(x => this.ProcessThisEmployee(x, cs.Token));
            }
            catch (AggregateException ae)
            {
                // error handling code
            }
            // other stuff
        }
