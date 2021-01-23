    public Form1() {
       	InitializeComponent();
        btnMoveUp.Enabled = false;
        btnMoveDown.Enabled = false;
    }
    private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e) {			
        btnMoveUp.Enabled = (lstPlayers.SelectedIndex != 0);
        btnMoveDown.Enabled = (lstPlayers.SelectedIndex != lstPlayers.Items.Count - 1);
    }
		private void btnMoveUp_Click(object sender, EventArgs e) {
			var index = lstPlayers.SelectedIndex;
			var item = lstPlayers.SelectedItem;
			lstPlayers.Items.Insert(index - 1, item);
			lstPlayers.Items.RemoveAt(index + 1);
			lstPlayers.SetSelected(index - 1, true);
		}
		private void btnMoveDown_Click(object sender, EventArgs e) {
			var index = lstPlayers.SelectedIndex;
			var item = lstPlayers.SelectedItem;
			lstPlayers.Items.Insert(index + 2, item);
			lstPlayers.Items.RemoveAt(index);
			lstPlayers.SetSelected(index + 1, true);
		}		
	}
