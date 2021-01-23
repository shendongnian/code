    protected void chkFacility_SelectedIndexChanged(object sender, EventArgs e) {
        //disables all the checkboxes when "All" is selected
        if (chkFacility.SelectedIndex==0) {
            foreach(ListItem aListItem in chkFacility.Items) {
                aListItem.Selected = true;
                if (aListItem.Value != "All") {
                    aListItem.Enabled = false;
                }
            }
        } else if (chkFacility.SelectedIndex > 0) {
            var i = 0;
            foreach(ListItem aListItem in chkFacility.Items) {
                if (aListItem.Selected) {
                    i++;
                }
            }
            //with the i++ check above, this handles unchecking every checkbox when each location is selected and the "All" checkbox is unchecked
            if (i == 9) {
                foreach(ListItem aListItem in chkFacility.Items) {
                    aListItem.Selected = false;
                    aListItem.Enabled = true;
                }
            //disables the "All" checkbox in all other cases where 8 or fewer of the 9 locations are selected
            } else {
                foreach(ListItem aListItem in chkFacility.Items) {
                    if (aListItem.Value == "All") {
                        aListItem.Enabled = false;
                    }
                }
            }
        //if no locations are selected after PostBack, make sure all checkboxes are enabled
        } else if (chkFacility.SelectedIndex == -1) {
            foreach(ListItem aListItem in chkFacility.Items) {
                aListItem.Enabled = true;
            }
        }
    }
