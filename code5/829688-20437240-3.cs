    public class DifferentViewModel()
    {
        public DifferentViewModel()
        {
            this.bar = ViewModel.Instance.foo;
        }
        public string bar;
    }
