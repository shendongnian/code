    private readonly SynchronizationContext _uiSynch;
    public Worker(UpdateValueCallback updateValueCallback, Player player)
    {
        _uiSynch = MainForm.Get.UISynchContext;
    }
    _uiSynch.Send(o =>
    {
        string labelName = "lbOne";
        string labelText = methodThatReturnsNewText();
        MainForm.Get.UpdateText(labelName, labelText);
    }, null);
