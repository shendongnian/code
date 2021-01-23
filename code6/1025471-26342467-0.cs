    // ...
    // Initialize the component
    srcDesignTime.ProvideComponentProperties();
    // Remove default inputs and outputs
    sourceComponent.OutputCollection.RemoveAll();
    sourceComponent.InputCollection.RemoveAll();
    int lastOutputId = 0;
    // ...
