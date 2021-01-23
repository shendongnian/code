    public class WorkspaceView : UserControl {
		public RibbonTabItem RibbonTabItem { get; set; }
		protected override void OnInitialized(EventArgs e) {
			base.OnInitialized(e);
			if (DesignerProperties.GetIsInDesignMode(this)) {
				if (RibbonTabItem != null) {
					object content = this.Content;
					DockPanel panel = new DockPanel();
					Content = panel;
					Ribbon ribbon = new Ribbon();
					ribbon.Tabs.Add(RibbonTabItem);
					panel.Children.Add(ribbon);
					panel.Children.Add((UIElement)content);
					DockPanel.SetDock(ribbon, Dock.Top);
					DockPanel.SetDock((UIElement)content, Dock.Bottom);
				}
			}
		}
	}
