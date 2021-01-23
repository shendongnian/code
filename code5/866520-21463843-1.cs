        private void E1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			
		    int zOrder = Canvas.GetZIndex(E2)+1;
			Canvas.SetZIndex(E1,zOrder);
					
		}
		private void E2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			
			int zOrder = Canvas.GetZIndex(E1)+1;
			Canvas.SetZIndex(E2,zOrder);
			
		}
