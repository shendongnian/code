    public void Application_Startup(object sender, StartupEventArgs e)
    {
        bool Absicherung;
        Mutex Mutex = new Mutex(true, this.GetType().GUID.ToString(), out Absicherung);
        if (Absicherung)
        {
            Window W = new Loadscreen();
            // W.Closed += (sender2, args) => Mutex.Close(); remove this from here
            W.Show();
        }
        .,. Mode code
    }
