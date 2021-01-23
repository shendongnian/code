    public LocationViewModel()
    {
        MessengerInstance.Register<LocationModel>(this,m=>{model=m;
                //PropertyChanged code
        });
    }
