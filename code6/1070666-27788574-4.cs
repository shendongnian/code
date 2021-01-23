    public sealed partial class SomePage
    {
        void SomeMethod()
        {
            var storyboard = VisualStateManager.GetVisualStateGroups(this.LayoutRoot).Get("MyStates").States.Get("MyAnimation").Storyboard;
        }
    }
    public static class StateExtensions
    {
        public static VisualStateGroup Get(this IList<VisualStateGroup> stateGroups, string name)
        {
            return stateGroups.Single(x => x.Name == name);
        }
        public static VisualState Get(this IList<VisualState> stateGroups, string name)
        {
            return stateGroups.Single(x => x.Name == name);
        }
    }
