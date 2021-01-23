    private void AddTrainerClass()
    {
        TrainerClassClientEntity trainerClass = new TrainerClassClientEntity();
        trainerClass.CopyValuesFrom(ViewModel.SelectedTrainerClass);
        ViewModel.TrainerClassesList.Add(trainerClass);
        ViewModel.SelectedTrainerClass = trainerClass;
    }
