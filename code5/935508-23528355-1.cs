    Class InformationMyTravelsList<T> : List<T>
    {
        public int id{get; private set;}
        public void AddInfo(int ID, InformationMyTravels info)
        {
            this.id = ID;
            this.Add(info);
        }
    
    }
    Class Main
    {
        void myLogic()
        {
            InformationMyTravels info = new InformationMyTravels();
            InformationMyTravelsList<InformationMyTravels> infoList = new InformationMyTravelsList<InformationMyTravels>();
            infoList.AddInfo(info); //add as many you want
            List<InformationMyTravelsList<InformationMyTravels>> myList = new InformationMyTravelsList<InformationMyTravels>>();
            myList.Add(infoList);
            myListBox.DataSource = myList;
        }
    }
