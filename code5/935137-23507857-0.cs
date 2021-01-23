    //long running code
    DoSomethingStage1();
    progressBar.Value = 30;
    Application.DoEvents(); // update the GUI
    DoSomethingStage2();
    progressBar.Value = 60;
    Application.DoEvents(); // update the GUI
    DoSomethingStage3();
    progressBar.Value = 100;
    Application.DoEvents(); // update the GUI
