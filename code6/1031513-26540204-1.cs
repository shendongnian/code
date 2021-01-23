	public class BindableGrid : Grid
	{
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register( "ItemsSource", typeof( IEnumerable ), typeof( BindableGrid ), new FrameworkPropertyMetadata( null, OnItemsSourceChanged ) );
		public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register( "ItemTemplate", typeof( DataTemplate ), typeof( BindableGrid ), new FrameworkPropertyMetadata( null, OnItemTemplateChanged ) );
		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue( ItemsSourceProperty ); }
			set { SetValue( ItemsSourceProperty, value ); }
		}
		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue( ItemTemplateProperty ); }
			set { SetValue( ItemTemplateProperty, value ); }
		}
		public static void OnItemsSourceChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			( (BindableGrid)d ).OnItemsSourceChanged( (IEnumerable)e.OldValue, (IEnumerable)e.NewValue );
		}
		public void OnItemsSourceChanged( IEnumerable oldValue, IEnumerable newValue )
		{
			INotifyCollectionChanged oldValueNotify;
			if( ( oldValueNotify = oldValue as INotifyCollectionChanged ) != null )
			{
				oldValueNotify.CollectionChanged -= ItemsSourceCollectionChanged;
			}
			INotifyCollectionChanged newValueNotify;
			if( ( newValueNotify = newValue as INotifyCollectionChanged ) != null )
			{
				newValueNotify.CollectionChanged += ItemsSourceCollectionChanged;
			}
		}
		public static void OnItemTemplateChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			( (BindableGrid)d ).OnItemTemplateChanged( (DataTemplate)e.OldValue, (DataTemplate)e.NewValue );
		}
		public void OnItemTemplateChanged( DataTemplate oldItemTemplate, DataTemplate newItemTemplate )
		{
		}
		private void ItemsSourceCollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
		{
			if( e.Action == NotifyCollectionChangedAction.Reset )
			{
				RowDefinitions.Clear();
				Children.Clear();
			}
			else if( e.Action == NotifyCollectionChangedAction.Add )
			{
				AddItems( e.NewItems );
			}
			else
			{
				throw new InvalidOperationException( string.Format( "Action '{0}' is not valid.", e.Action ) );
			}
		}
		private void AddItems( IList items )
		{
			foreach( var item in items )
			{
				if( Children.Count > 0 )
				{
					RowDefinitions.Add( new RowDefinition { Height = GridLength.Auto } );
					var gridSplitter = new GridSplitter
					{
						Height = 5,
						Background = new SolidColorBrush( Color.FromArgb( 255, 0, 0, 0 ) ),
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Stretch,
					};
					SetRow( gridSplitter, Children.Count );
					Children.Add( gridSplitter );
				}
				RowDefinitions.Add( new RowDefinition
				{
					Height = new GridLength( 1, GridUnitType.Star ),
					MinHeight = 40,
				} );
				var contentPresenter = new ContentPresenter();
				contentPresenter.SetValue( ContentPresenter.ContentTemplateProperty, ItemTemplate );
				contentPresenter.Content = item;
				SetRow( contentPresenter, Children.Count );
				Children.Add( contentPresenter );
			}
		}
	}
