    public bool Favorite
        {
            get { return favorite; }
            set
            {
                if (favorite != value)
                {
                    favorite = value;
                    //Update the database 
                    UpdateDatabase();
                    OnPropertyChanged("Favorite");
                }
            }
        }
