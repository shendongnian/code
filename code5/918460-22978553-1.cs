        public async Task<ActionResult> Sample()
        {
            int id1 = Thread.CurrentThread.ManagedThreadId;
            int hash1 = _uow.GetHashCode();
    
            var task = SignInAsync(account, isPersistent: false);
            Debug.Print("completed synchronously: " + task.IsCompleted);
            await task;    
            int id2 = Thread.CurrentThread.ManagedThreadId; //same as id1
            int hash2 = _uow.GetHashCode(); //same as hash1
    
            return Content("");
        }
