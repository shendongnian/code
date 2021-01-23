    private static object lockObject = new object();
    protected override void WndProc(ref Message message) {
        if (id != null) {
            id.ProcessMessage(message);
            lock(lockObject) {
                if (id.ScanCode.Length > 4) {
                    ...
                }
            }
        }
    
        base.WndProc(ref message);
    }
