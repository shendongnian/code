    class YourClass : Interface {
        public void ReadEntity()
        {
           delegateTo.ReadEntity();
        }
        TableEntity delegateTo = new TableEntity();
    }
