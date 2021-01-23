                if (ddlTicketViewCategory.SelectedItem != null)
                {
                    var FilteredList = Tickets.Where(Filter => Filter.Category == ddlTicketViewCategory.SelectedItem.ToString()).ToList();
                }
                dgvTickets.DataSource = FilteredList;
                dgvTickets.DataBind();
