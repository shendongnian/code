    public void method() {
        using(var transactionScope = new TransactionScope()) {
            _context.SaveChanges();
        }
    }
