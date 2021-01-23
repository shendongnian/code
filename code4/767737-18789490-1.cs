       private void MyView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
       {
            var border = (Control)sender;
            if (border.IsVisible)
            {
                //Window ss = new Window();
                //ss.Loaded += new RoutedEventHandler(ss_Loaded);
                //ss.ShowDialog();
                using (BackgroundWorker bg = new BackgroundWorker())
                {
                    bg.DoWork += new DoWorkEventHandler(bg_DoWork);
                    bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
                    Tuple<Control, double> b = new Tuple<Control, double>(border, border.Height);
                    bg.RunWorkerAsync(b);
                }
            }
       }       
        
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (e.Result as UserControl).BringIntoView();
        }
        
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {   
            int maxwait = 300 //not scrolled to the view is not a disaster, but if the program hangs forever it will be a disaster, so set this to prevent that from happening
            while (maxwait!=0 
                   && 
                   (e.Argument as Tuple<Control, double>).Item1.ActualHeight != (e.Argument as Tuple<Control, double>).Item2)
            {
                Thread.Sleep(1);
                maswait--;
            }
            e.Result = (e.Argument as Tuple<Control, double>).Item1;
        }  
