        public static void BC_RunExistingBCModel(object sender, DoWorkEventArgs e)
        {
                RC2___RhinegoldCoreForm frmC = e.Argument as RC2___RhinegoldCoreForm;
                BackgroundWorker watchboxWorker = new BackgroundWorker();
                watchboxWorker.DoWork += frmC.WatchboxWorker_RunProc;
                watchboxWorker.RunWorkerAsync(batLoc);
                while (watchboxWorker.IsBusy)
                    Thread.Sleep(50);
                frmC.UpdateRGCoreStatusBox4("Executed script " + m + "... ");
         }
            
