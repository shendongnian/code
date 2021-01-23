    Microsoft.Office.Interop.PowerPoint.Application objPPT;
    Microsoft.Office.Interop.PowerPoint.Presentations objPresentations;
    Microsoft.Office.Interop.PowerPoint.Presentation objCurrentPresentation;
    Microsoft.Office.Interop.PowerPoint.SlideShowView objSlideShowView;
    private void StartPowerPointPresentation(object sender, EventArgs e)
    {
        // Open an instance of PowerPoint and make it visible to the user
        objPPT = new Microsoft.Office.Interop.PowerPoint.Application();
        objPPT.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
        //Open a presentation
        OpenFileDialog openDlg = new OpenFileDialog();
        openDlg.Filter = "Powerpoint|*.ppt;*.pptx|All files|*.*";
        if (opendlg.ShowDialog() == true)
        {
            //Open the presentation
            objPresentations = objPPT.Presentations;
            objCurrentPresentation = objPresentations.Open(openDlg.FileName, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            //Hide the Presenter View
            objCurrentPresentation.SlideShowSettings.ShowPresenterView = MsoTriState.msoFalse;
            //Run the presentation
            objCurrentPresentation.SlideShowSettings.Run();
            //Hold a reference to the SlideShowWindow
            objSlideShowView = objCurrentPresentation.SlideShowWindow.View;
        }
    }
    private void ShowNextSlide(object sender, EventArgs e)
    {
        //Unless running on a timer you have to activate the SlideShowWindow before showing the next slide
        objSlideShowView.Application.SlideShowWindows[1].Activate();
        //Go to next slide
        objSlideShowView.Next();
    }
