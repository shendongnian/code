    public class DifferentViewModel()
    {
        public DifferentViewModel()
        {
            this.bar = ViewModel.Instance.foo;
        }
        private string bar;
    }
