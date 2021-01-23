    // this is what you used to have as a delegate declaration {
    public interface IWorkCompletedListener {
        public void someMethodName(Object sender, Object args);
    }
    // }
    // class A will be the event provider
    public class A {
        // this is what you used to have for an event declaration {
        // used for the storage of listeners
        private static Vector<IWorkCompletedListener> workComplete = new Vector<IWorkCompletedListener>();
        // used for +=
        public static void addWorkCompleteListener(IWorkCompleteListener listener) {
            A.workComplete.add(listener);
        }
        // used for -=
        public static void removeWorkCompleteListener(IWorkCompleteListener listener) {
            A.workComplete.remove(listener);
        }
        // }
        // this is what you would use to raise the event {
        private static void raiseWorkCompletedListener(Object sender, Object args) {
            for (IWorkCompletedListener listener : A.workComplete)
                listener.someMethodName(sender, args);
        }
        // }
        // and the test code
        public static void doWork() {
            // Stuff goes here
            A.raiseWorkCompletedListener(null, null);
        }
  
    }
    // class B will be the event consumer
    public class B {
        public static void subscribeAndCallDoWork() {
            // this is what += used to be
            A.addWorkCompleteListener(new IWorkCompletedListener {
                public void someMethodName(Object sender, Object args) {
                   
                    // I didn't want to force class B to implement the interface
                    // hence I used an anonymous interface implementation
                    // from which I'm calling the "event handler"
                    B.onWorkCompleted(sender, args);
                }
            });
            A.doWork();
        }
        private static onWorkCompleted(Object sender, Object args) {
           // expect to be called here
        }
    }
