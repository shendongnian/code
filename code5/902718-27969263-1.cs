    public void GoToPatientsManager()
    {
        var patientManagerViewModel = IoC.Get<PatientsManagerViewModel>();
        ActivateItem(patientManagerViewModel);
    }
