    BackgroundWorker bw = new BackgroundWoker();
     private void login_Click(object sender, RoutedEventArgs e)
            {
                 bw.DoWork += (sender3,args3) => { 
                    timer.Tick += (sender2, args) => {
                        if (classes.WebDataAccess.LoginBag.propBag.Count > 1)
                        {
                        ....
