    public class Reference<T> {
        public T Value;
        public Reference(T value) {
            Value=value;
        }
    }
    public static void Test() {
        Task<Reference<int>> parent=Task.Factory.StartNew(() => {
            var sum=new Reference<int>(0);
            TaskFactory tf=new TaskFactory(TaskCreationOptions.AttachedToParent,
            TaskContinuationOptions.ExecuteSynchronously);
            tf.StartNew(() => sum.Value++);
            tf.StartNew(() => sum.Value++);
            tf.StartNew(() => sum.Value++);
            return sum;
        });
        var finalTask=parent.ContinueWith(parentTask => Console.WriteLine(parentTask.Result.Value));
        finalTask.Wait();
    }
