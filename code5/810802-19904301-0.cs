    private class BossAttack
    {
        public DateTime AttackTime;
        //... Other properties
    }
    List<BossAttack> pendingAttacks = new List<BossAttack>();
    // Adding a boss attack
    lock (pendingAttacks)
    {
        pendingAttacks.Add(new BossAttack()
        {
             AttackTime = DateTime.Now;
             ...
        }
    }
