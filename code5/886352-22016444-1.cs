        // Returns the top object on the stack without removing it.  If the stack
        // is empty, Peek throws an InvalidOperationException.
        public virtual Object Peek() {
            if (_size==0)
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
            Contract.EndContractBlock();
            return _array[_size-1];
        }
