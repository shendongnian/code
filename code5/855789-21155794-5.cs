    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }        
        public void Buy(Property property)
        {
            // TODO: Handle (property.Price > Money) case
            Money -= property.Price;
            property.Owner = this;            
        }
        public void PayRent(Property property)
        {
            // TODO: Handle (property.Rent > Money) case
            Money -= property.Rent;
            property.Owner.Money += property.Rent;
        }
    }
