    private List<ZooKeeperBase> _zooKeepers = new List<ZooKeeperBase>();
    public void CareForAnimal<T>(T animal) where T : Animal
        {
            //How do I find the Zoo Keeper that Cares for this Animal?? 
            //A List definitely isn't what I want.. I won't have o(1) Lookup, plus how do I know
            //Which concrete Animal that ZooKeeper cares about?
            foreach (ZooKeeperBase keeper in _zooKeepers)
            {
                var thisKeeper = keeper as ZooKeeper<T>;
                if (thisKeeper != null)
                {
                    thisKeeper.CareForAnimal(animal);
                    return;
                
                }
            }
        }
