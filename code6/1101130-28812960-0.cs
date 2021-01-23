			protected void lbListView_Click(object sender, EventArgs e)
			{
				lbGridView.CssClass = "btn btn-default btn-sm pull-right dt-margin-left-5";
				lbGridView.Enabled = true;
				lbListView.CssClass = "btn btn-default btn-sm pull-right dt-margin-left-5 active";
				lbListView.Enabled = false;
				repGridResults.Visible = false;
				repListResults.Visible = true;
			}
			protected void lbGridView_Click(object sender, EventArgs e)
			{
				lbListView.CssClass = "btn btn-default btn-sm pull-right dt-margin-left-5";
				lbListView.Enabled = true;
				lbGridView.CssClass = "btn btn-default btn-sm pull-right dt-margin-left-5 active";
				lbGridView.Enabled = false;
				repListResults.Visible = false;
				repGridResults.Visible = true;
			}
