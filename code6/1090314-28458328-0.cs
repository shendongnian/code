        private void myCombo_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ControlTemplate ct = this.myCombo.Template;
			Popup pop = ct.FindName("PART_Popup", this.myCombo) as Popup;
			pop.Placement = PlacementMode.Top;
		}
