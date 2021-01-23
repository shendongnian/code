    public sealed class RemoveStoryboard : ControllableStoryboardAction
    {
        public RemoveStoryboard()
        {
        }
        internal override void Invoke(FrameworkElement containingFE, FrameworkContentElement containingFCE, Storyboard storyboard)
        {
            if (containingFE != null)
            {
                storyboard.Remove(containingFE);
                return;
            }
            storyboard.Remove(containingFCE);
        }
    }
