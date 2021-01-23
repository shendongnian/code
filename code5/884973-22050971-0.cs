   	[TestMethod]
		public void CodedUITestMethod1()
		{
			WinWindow window = new WinWindow();
			window.SearchProperties[WinWindow.PropertyNames.Name] = "Error Window";
			WinButton okButton = new WinButton(window);
			okButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
			try
			{
				throw new Exception("Coded UI is throwing an exception.  No idea about the Internet explorer state.");
			}
			catch(Exception ex)
			{
				Task.Run(() =>
					{
						MessageBox.Show(ex.Message, "Error Window");
					}).Start();
				throw new Exception("An unexpected exception occurred in Coded UI",ex);
			}
			finally
			{
				Image pic = window.CaptureImage();
				pic.Save(@"C:\result.bmp");
				Mouse.Click(okButton);
			}
		}
