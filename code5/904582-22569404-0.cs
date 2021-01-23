            var master = (Tab)Master;
            master.GridSearchResults.DataSource = null;
            var sessions = new Sessions();
            sessions.SlideOutSource.Add(new MyProperties {
                                           Id = Id,
                                           StartDate = hidStartDate.Value,
                                           Installation = txtInstall.Text,
                                           Command = txtCommand.Text  });
            master.GridSearchResults.DataSource = sessions.SlideOutSource;
            master.GridSearchResults.DataBind(); 
