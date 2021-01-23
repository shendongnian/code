    Microsoft.Office.Interop.PowerPoint.Presentation objPres;
                    Microsoft.Office.Interop.PowerPoint.SlideShowView oSlideShowView;
                    objPres = Globals.ThisAddIn.Application.ActivePresentation;
                    objPres.SlideShowSettings.ShowPresenterView = MsoTriState.msoFalse;
    PowerPoint.Slide curSlide_1 = ppApp.ActiveWindow.View.Slide;
                    objPres.SlideShowSettings.Run();
                    oSlideShowView = objPres.SlideShowWindow.View;                
                    oSlideShowView.GotoSlide(curSlide_1.SlideIndex);
