    public interface IPrayerAggregator
    {
        void Pray(Believer believer, string prayer);
        void RegisterGod(God god);
    }
    
    // god does
    prayerAggregator.RegisterGod(this);
    // believer does
    prayerAggregator.Pray(this, "For the victory!");
