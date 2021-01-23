               try
                {
                    printer = new Printer();
                    printer.PrintTicket(dataAdv);
                    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
                    dispatcherTimer.Start();
                }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (monitorPrinter.IsPrinterReady() == false)
            {
                MessageBox.Show("SOME PROBLEM WHEN PRINTING!");
            }
        }
