		this.WebBrowser.Navigated += (sender, args) =>
		{
			if (args.Uri.AbsolutePath == "/connect/login_success.html")
			{
				if (args.Uri.Query.Contains("error"))
				{
					MessageBox.Show("Error logging in.");
				}
				else
				{
					string fragment = args.Uri.Fragment;
					var collection = HttpUtility.ParseQueryString(fragment.Substring(1));
					string token = collection["access_token"];
                    
                    // Save the token somewhere to give back to your code
				}
				this.Close();
			}
		};
