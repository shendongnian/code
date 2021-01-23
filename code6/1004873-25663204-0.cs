    // PUT Api/<controller>/5
    [Transaction]
    public void Put(int id, RequestNameChangesViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var command = new SaveOrUpdateRequestNameChangeCommand(
                id,
                viewModel.Username,
                viewModel.OriginalFirstName,
                viewModel.OriginalLastName,
                viewModel.NewFirstName,
                viewModel.NewLastName,
                viewModel.EffectiveDate,
                viewModel.NewEmailAddress,
                viewModel.IsRetailUser,
                viewModel.SpecialRequirements,
                viewModel.Notes,
                viewModel.ServiceDeskId,
                viewModel.ServiceDeskUrl,
                viewModel.RequestNameChangeId,
                viewModel.DateCreated,
                viewModel.CreatedBy
                );
    
            if (ModelState.IsValid)
            {
                commandProcessor.Process(command);
                viewModel.RequestNameChangeId = command.RequestNameChangeId;
            }
        }
    }
