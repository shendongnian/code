        private void E1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			
		    int zOrder = Canvas.GetZIndex(R2)+1;
			Canvas.SetZIndex(R1,zOrder);
					
		}
		private void E2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			
			int zOrder = Canvas.GetZIndex(R1)+1;
			Canvas.SetZIndex(R2,zOrder);
			
		}
