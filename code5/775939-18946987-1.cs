    static class StateFactory
    {
        static State GetState(condition)
        {
            if(condition == something)
                return new StateOne();
            else ...
        }
    }
