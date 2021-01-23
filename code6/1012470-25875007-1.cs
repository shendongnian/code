        public FormModelConfigurarAreaItem()
        {
            DatabaseEntities db=new DatabaseEntities ();
            Agrupaciones = db.AgrupacionChequeos.ToList();
        }
