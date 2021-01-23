    private void MainClassBtn_Click(object sender, RoutedEventArgs e)
    {
        vtkInteractorObserver istyle = goPreviewer.ImageViewer.GetRenderWindow()
            .GetInteractor().GetInteractorStyle();
        istyle.LeftButtonReleaseEvt += (s,args) =>
            DoSomethingWithArray(OtherClass.OtherClassLeftReleasedCb());
    }
