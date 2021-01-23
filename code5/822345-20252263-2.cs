		protected void postUpdateButton_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
			{
				return;
			}
			twitterCtx.UpdateStatus(updateBox.Text);
			updateBox.Text = string.Empty;
		}
