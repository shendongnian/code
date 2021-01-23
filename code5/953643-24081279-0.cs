    private void submitMenu_Click(object sender, EventArgs e)
    {
        MedicineModel viewModel = App.ViewModel;
        List<MedicineData> problems = viewModel.Problems;
        string problemName = problems[0].ProblemName;
    }
