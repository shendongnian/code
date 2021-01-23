            if(this.location == null && this.location.selecteditem ==null && this.location.selecteditem.locationID == null)
            {
              this.ShowMessageBox("test"); //not sure what to put there so I just made something up
            }    
    
            else if (this.location.SelectedItem.locationID.Contains("CMP"))
            {
                this.FindControl("datePurchased").IsVisible = true;
                this.FindControl("age").IsVisible = true;
                this.FindControl("userList").IsVisible = true;
            }
            else
            {
                    this.FindControl("datePurchased").IsVisible = false;
                    this.FindControl("age").IsVisible = false;
                    this.FindControl("userList").IsVisible = false;
            }
