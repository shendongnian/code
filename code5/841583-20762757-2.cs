        public void ServiceLoop()
        {
            // Guaranteed nothing else will be executed until 
            // the reset event is signalled
            _resetEvent.WaitOne(); 
            while (_running) { /* .. */ }
        } 
