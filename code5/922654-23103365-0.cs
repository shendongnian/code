    public void tryLoop(Action anyMethod) {
        while ( true ) {
            // Could be replaced by timer timeout
            try {
                anyMethod();
                break;
            }
            catch {
                System.Threading.Thread.Sleep(2000); // wait 2 seconds
            }
        }
    }
