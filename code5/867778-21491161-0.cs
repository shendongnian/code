    public MVMMPhi(Input data)
    {
        MeaMPhis = new Collection<MeaMPhi>();
        for (int i = 0; i < 40; i++)
        {
                MeaMPhis.Add(new MeaMPhi
                                     {
                                         Curvature = data.curvature[i],
                                         Moment = data.moment[i]
                                     });
        }
    }
