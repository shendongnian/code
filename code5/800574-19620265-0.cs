    private void AddTrainerClass()
    {
        TrainerClassClientEntity trainerClass = new TrainerClassClientEntity(
            ViewModel.SelectedTrainerClass);
        ViewModel.TrainerClassesList.Add(trainerClass);
        ViewModel.SelectedTrainerClass = trainerClass;
    }
