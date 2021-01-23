    if (this.checkedListBoxChannels.CheckedItems.Count == 1) {
				if (e.NewValue == CheckState.Unchecked) {
					this.btnOK.Enabled = false;
				}
			}
			else {
				this.btnOK.Enabled = true;
			}
