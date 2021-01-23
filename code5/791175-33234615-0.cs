            listener = new MvxPropertyChangedListener(IncidentViewModel).Listen<bool>(
                () => IncidentViewModel.IsBusy,
                () =>
                {
                    if (IncidentViewModel != null && !IncidentViewModel.IsBusy)
                    {
                        LoadControls();
                    }
                });
