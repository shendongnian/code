    public static class Queue {
        // static volatile bool isProcessing;
        static volatile object locker = new Object();
        public static void Process() {
            lock (locker) {
                // if (!isProcessing) {
                //  isProcessing = true;
                    //Process Queue...
                //  isProcessing = false;
                // }
            }
        }
    }
