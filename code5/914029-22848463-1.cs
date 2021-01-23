		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				//txtBoxEnvironment.Text = CurrentEnvironment;
				//DAL.setConnectionString(CurrentEnvironment);
			}
			ProgressUpdatePanel.ContentTemplateContainer.Controls.Add(lblCaption);
			ProgressUpdatePanel.Update();
			lblCaption.Text = "";
		}
		protected void btnCreateFiles_Click(object sender, EventArgs e) {
			//All of the processing is done here...
			//This works correctly the first time a user click the button
			//But the second time, this text remains and the 'Please wait...' text from the lblProgress label
			// is added above this text.
			ProgressUpdatePanel.ContentTemplateContainer.Controls.Add(lblCaption);
			ProgressUpdatePanel.Update();
			lblCaption.Text = "Processing...completed.";
			System.Threading.Thread.Sleep(1000);
			ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "bindButton", "bindButton();", true);
		}
