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
            while ((e.Argument as Tuple<Control, double>).Item1.ActualHeight != (e.Argument as Tuple<Control, double>).Item2)
            {
                ;
            }
            e.Result = (e.Argument as Tuple<Control, double>).Item1;
        }  
