    public static dynamic PrepareForMusiciansView(IQuerable<Musician> musicians)
    {
        return musicians.Select(m => new
                     {
                        musicianId = m.MusicianId,
                        name = m.Name,
                        instrument = new 
                                     {
                                        instrumentId = m.instrument.InstrumentId,
                                        model = m.instrument.Model
                                     }
                     }
    }
