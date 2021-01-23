    public class TaskClass
    {
        public static ChangeStatus(Accounts.Account a, MyTask t, Status s)
        {...}
    }
    private void Main() {
        Accounts.Account account = new Accounts.Account();
        TaskClass.Task task = new TaskClass.Task();
        TaskClass.ChangeStatus(account, task, Status.Active);
    }
