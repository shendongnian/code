    private void button1_Click(object sender, RoutedEventArgs e)
            {
                progressBar1.Visibility = Visibility.Visible;
                Thread t = new Thread(DoMyWork);
                t.Start();
            }
    
       private void DoMyWork()
                    {
                        Thread.Sleep(5000);
                        //hide the progress bar after completing your work
                        this.Dispatcher.Invoke((Action)delegate { progressBar1.Visibility = Visibility.Hidden; });
                    }
    
