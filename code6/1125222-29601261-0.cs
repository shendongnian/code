    public class StoryboardReactionBehavior : DependencyObject, IBehavior
    {
	public DependencyObject AssociatedObject { get; private set; }
	public void Attach(DependencyObject associatedObject)
	{
		AssociatedObject = associatedObject;
		(AssociatedObject as UIElement).Tapped += StoryboardReactionBehavior_Tapped;
	}
	private void StoryboardReactionBehavior_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
	{
	  
	}
	public void Detach()
	{
		(AssociatedObject as UIElement).Tapped -= StoryboardReactionBehavior_Tapped;
	}
