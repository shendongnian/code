	[ContentProperty("InternalContent")]
	public class WindowBase : Window
	{
		// InternalContent
		public static readonly DependencyProperty InternalContentProperty = 
			DependencyProperty.Register( "InternalContent", typeof(object),
			typeof(WindowBase), new FrameworkPropertyMetadata(null));
		 
		public object InternalContent
		{
			get { return GetValue(InternalContentProperty); }
			set { SetValue(InternalContentProperty, value); }
		}
		...
	}
	<Window ...>
		<Grid>
			...
			<ContentControl IsTabStop="false"
				Content="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}, Path=InternalContent}" />
			<Canvas />
			...
		</Grid>
	</Window>
