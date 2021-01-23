    public class Priest : IPrayerAggregator
    {
        private List<WeakReference> _gods;
     
        public void Pray(Believer believer, string prayer)
        {
            foreach (WeakReference godRef in _gods) {
                God god = godRef.Target as God;
                if (god != null)
                    god.SomeonePrayed();
                else
                    _gods.Remove(godRef);
            }
        }
    
        public void RegisterGod(God god)
        {
            _gods.Add(new WeakReference(god, false));
        }
    }
