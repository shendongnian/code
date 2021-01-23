     // Complete all interactions with UI to get data before using another thread
        double x1_min = Convert.ToDouble(txt_x1_min.Text);
        double x1_max = Convert.ToDouble(txt_x1_max.Text);
        double x2_min = Convert.ToDouble(txt_x2_min.Text);
        double x2_max = Convert.ToDouble(txt_x2_max.Text);
        int iter = Convert.ToInt16(txtIterations.Text);
    
        ThreadPool.QueueUserWorkItem((state) =>
            {
                //Data Defining and Computing that are not dependent on any UI elements
                obj.Run(x1_min, x1_max, x2_min, x2_max, iter);     
                var data = PSOLib.table.DefaultView;
    
                Dispatcher.Invoke(new Action(() =>
                {
                    //Update the UI
                    myDataGrid.ItemsSource = data;
                    Minima.Text = string.Format("{0,0:0.000} ", PSOLib.min);
                }));
            });
