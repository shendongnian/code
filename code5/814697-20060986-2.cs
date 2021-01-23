    public class NavigationTargetAttribute : Attribute
    {
        private readonly Type target;
        public ViewModelBase Target
        {
            get { return target; }
        }
        public NavigationTargetAttribute(Type target)
        {
            this.target = target;
        }
    }
