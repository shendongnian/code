    private void metroButton27_Click_2(object sender, EventArgs e)
    	{
    		if (metroTextBox16.Text == "") //Checks if Textbox = Blank.
    			{
    				MessageBox.Show("Enter a username.", "ERROR"); //Shows a message box.
    			}
    			else
    			{
    			this.metroTextBox16.Text = new WebClient().DownloadString("http://resolveme.org/api.php?key=51e77c68b11df&skypePseudo=" + this.metroTextBox15.Text);
    			
    			}
    		}
