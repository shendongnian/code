        class Users
        {
            public Users()
            {
                officeList = new List<Offices>();
                caseAdminIDList = new List<int>();
                ID = 0;
            }//end constructor
    
            private List<Offices> officeList;
            public List<Offices> OfficeList
            {
                get { return officeList; }
                set { officeList = value; }
            }
            private List<int> caseAdminIDList;
            public List<int> CaseAdminIDList 
            {
                get { return caseAdminIDList; }
                set { caseAdminIDList = value; }
            }
            //other members.....
         }
