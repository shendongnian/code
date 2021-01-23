        class Users
        {
            public Users()
            {
                officeList = new List<Offices>();
                ID = 0;
            }//end constructor
    
            private List<Offices> officeList;
            public List<Offices> OfficeList
            {
                get { return officeList; }
                set { officeList = value; }
            }
            //other members.....
         }
