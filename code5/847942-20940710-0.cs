    public class Player 
    {
        private string name {get;set;}
        private string job {get;set;}
        private string STR;
        private string DEX;
        private string VIT; 
        //etc..
    
        private List<Ability> rotation = new List<Ability>();
    
        public void execute()
        {
            foreach (var ab in rotation)
            {
                ab.execute();
            }
        }
    
        public void setUpRotation()
        {
            var rot = new List<Ability>();
            setUpRotation(rot);
            foreach (var ab in rot)
            {
                ab.Player = this;
            }
        }
    
        protected virtual void setUpRotation(List<Ability> rotation) { }
    }
    
    //I want to make the program a bit modular for jobs (roles/classes)
    //So.. 
    
    public class Bard : Player
    {
        protected override void setUpRotation(List<Ability> rotation)
        {
            rotation.Add(new Heavyshot());
            //etc.
        }
    
        public class Heavyshot : Ability 
        {
            public Heavyshot() 
            {
                name = "Heavy Shot";
                potency = 150;
                dotPotency = 0;
                recastTime = 2.5;
                TPcost = 60;
                animationDelay = 0.8;
                abilityType = "Weaponskill";
                castTime = 0.0;
                duration = 0.0;
            }
    
            public override void impact() 
            {
                //add heavier shot buff activation here
                base.impact(); 
            }
        }
    
        public class Ability{
            public Player Player { get; set; }
            
            public int cooldown;
            public int cost;
            public virtual void impact() 
            {
                //Deal some damage.
                // !! - the key problem is here, i want to initiate a roll to compare to the players CRIT rating versus the roll to determine the bonus damage. But I can't access the initiated players crit from here. The rating may change depending on abilities used so I can't create a new object. I know i need an object reference but I can't figure it out...
                log(time.ToString("F2") + " - " +  name + 
                    " Deals " + potency + 
                    " Potency Damage. Next ability at: " + nextability);
            }
        }
    }
