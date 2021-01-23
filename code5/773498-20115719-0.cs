    protected void personForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (this.ModelState.IsValid)
			{
				labResponse.Text = "New record added. Woohoo!";
			}
			else
			{
				labResponse.Text = "";
			}
			personForm.DefaultMode = FormViewMode.Insert;
		}
