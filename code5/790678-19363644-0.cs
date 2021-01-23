        MijnConnectie.Open();
        myReader = mysqlcommand.ExecuteReader();
        while (myReader.Read())
        {
            var ucTemp = new ucDBControl();
            //create and initialize the usercontrol
            string onderwerp = myReader.GetString("onderwerpBijstandAanvraag");
            string PeriodeTot = myReader.GetString("PeriodeTot");
            ucTemp.Onderwerp = onderwerp;
            ucTemp.PeriodeTot = PeriodeTot ;
            //hold it in the list
           myListControl.Add(ucTemp);
            //and add it in the interface
            NieweTab(tabControl1, ucTemp);
            
        }
