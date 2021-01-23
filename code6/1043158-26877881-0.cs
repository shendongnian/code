			void Exec(string url)
			{
				var th = new Thread(() =>
				{
					using (WebBrowser wb = new WebBrowser())
					{
						wb.Name = "webBrowserGenerated" + Guid.NewGuid();
						List<Control> list = new List<Control>();
						GetAllControl(this, list);
						foreach (Control control in list)
						{
							if (control.GetType() == typeof(WebBrowser))
							{
								if (control.Name.StartsWith("webBrowserGenerated"))
								{
									control.Refresh();
								}
							}
						}
						wb.DocumentCompleted += (sndr, e) =>
						{
							// Do something when completed
							wb.Dispose();
							Application.ExitThread();
						};
						wb.Navigate(url);
						Application.Run();
					}
				});
				th.SetApartmentState(ApartmentState.STA);
				th.Start();
				th.Join();
			}
			
		private void GetAllControl(Control c, List<Control> list)
		{
			foreach (Control control in c.Controls)
			{
				list.Add(control);
				if (control.GetType() == typeof(Panel))
					GetAllControl(control, list);
			}
		}
