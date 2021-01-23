    // Definition of the data of Task1
    public class Task1Data
    {
        public string Arg;
        public int Arg1;
    }
    // The behavior of Task1
    public class Task1 : ITask<Task1Data> {
        public void Handle(TTask1Data data) {
            // here the behavior of this task.
        }
    }
