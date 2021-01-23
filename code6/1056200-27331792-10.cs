        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataString = "No Data";
            busyIndicator.Start();
                System.Threading.Thread.Sleep(5000);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    }
