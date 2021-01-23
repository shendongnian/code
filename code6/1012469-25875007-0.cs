        public FormModelConfigurarAreaItem()
        {
            InspeccionaEntities db=new InspeccionaEntities();
            Agrupaciones = db.AgrupacionChequeos.ToList();
        }
