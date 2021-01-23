    public class ParentViewModel
    {
        ChildViewModel childViewModel;
        public ParentViewModel()
        {
            childViewModel = new ChildViewModel(ActionMethod);
        }
        private void ActionMethod()
        {
            Console.WriteLine("Parent method executed");
        }
    }
    public class ChildViewModel
    {
        private readonly Action parentAction;
        public ChildViewModel(Action parentAction)
        {
             this.parentAction = parentAction;
             CallParentAction();
        }
        public void CallParentAction()
        {
            parentAction.Invoke();
        }
    }
