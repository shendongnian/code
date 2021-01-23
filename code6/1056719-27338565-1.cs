    protected void GridViewTicketHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drpnop = (DropDownList)e.Row.FindControl("DropDownList1");
            if (drpnop != null)
            {
                // populate drpnop items
                foreach (State state in entities.States)
                {
                    drpnop.Items.Add(new ListItem(state.StateName, state.StateID.ToString()));
                }
                // set the selected value of drpnop according to StateID of the ticket
                Ticket data = (Ticket)e.Row.DataItem;
                if (drpnop.Items.FindByValue(data.StateID.ToString()) != null)
                {
                    drpnop.Items.FindByValue(data.StateID.ToString()).Selected = true;
                }
            }
        }
    }
