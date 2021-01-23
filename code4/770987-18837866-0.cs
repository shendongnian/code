            int selectedRow = 0;
            try
            {
                
                if (EventsDataGrid.Rows.Count > 0)
                    selectedRow = EventsDataGrid.SelectedRows[0].Index;
                viewModel = new EventsViewModel();
                EventsViewModelSource.DataSource = viewModel;
               
                if (EventsDataGrid.Rows.Count > 0)
                {
                    EventsDataGrid.Rows[selectedRow].Selected = true;
                    NoteValueLabel.Text = viewModel.Events[selectedRow].Note;
                }
            }
            catch{}
        } 
