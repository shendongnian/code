    try
	{
		string[] RSSNews;
		loadingCircleFF.Visible = true;
		string address = txtRSSGroup_Address.Text.Trim();
		System.Threading.ThreadPool.QueueUserWorkItem((o) =>
		{
			RSSNews = Utility.RSSNews_Read(address);
			for (int i = 0; i < RSSNews.Length; i++)
			{
				if (RSSNews[i] != null && RSSNews[i] != string.Empty)
				{
					RSS.RSSGroup_ID = RSSGroupID;
					RSS.RSS_Content = RSSNews[i];
					RSS.RSS_PersianDate = FreeControls.PersianDate.Now.ToString("YYYY/MM/dd");
					RSS.User_FirstName = GlobalVariable.User_FirstName;
					RSS.User_LastName = GlobalVariable.User_LastName;
					RSS.Insert();
				}
				else
					break;
			}
			this.BeginInvoke(new Action(() => { 
				loadingCircleFF.Visible = false;
				//MessageBox.Show("عملیات به روز رسانی با موفقیت انجام شد.", "موفقیت");                            
				RSS.DeleteByGroup(RSSGroupID);
				//MessageBox.Show("عملیات به روز رسانی با موفقیت انجام شد.", "موفقیت");
				DTcancel_RSS(null, null);
			}));
            //If these methods don't access UI, call them normally, else wrap them with BeginInvoke.
            //RSS.DeleteByGroup(RSSGroupID);
            //DTcancel_RSS(null, null);
		});
	}
	catch
	{
		MessageBox.Show("خطا در دریافت اطلاعات از RSS", "خطا");
	}
    
