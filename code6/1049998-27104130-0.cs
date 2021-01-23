    		// Checks if the user exists in the blockedUsers.
			if (blockedUsers.ContainsKey(userName))
			{
				// If so, then gets the difference between when he was blocked and now.
				var diffInSeconds = (DateTime.Now - blockedUsers[userName]).TotalSeconds;
				// If the difference is smaller than 30, prevent him from loggin.
				if (diffInSeconds < 30)
				{
					MessageBox.Show("Sorry, but your user has been temporary blocked from loggin. Try later.");
					return;
				}
				// If the diff is greater than 30, then there is no reason to keep him in blocked list.
				else
				{
					blockedUsers.Remove(userName);
				}
			}
