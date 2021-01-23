    public class WorkspaceView : UserControl {
		public RibbonTabItem RibbonTabItem { get; set; }
		protected override void OnInitialized(EventArgs e) {
			base.OnInitialized(e);
			if (DesignerProperties.GetIsInDesignMode(this)) {
				if (RibbonTabItem != null) {
					UIElement content = this.Content as UIElement;
					DockPanel panel = new DockPanel();
					Content = panel;
					Ribbon ribbon = new Ribbon();
					ribbon.Tabs.Add(RibbonTabItem);
					DockPanel.SetDock(ribbon, Dock.Top);
					panel.Children.Add(ribbon);
					if (content != null) {
						panel.Children.Add(content);
						DockPanel.SetDock(content, Dock.Bottom);
					}
				}
			}
		}
	}
