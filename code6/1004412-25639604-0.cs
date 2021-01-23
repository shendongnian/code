	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ModelNumber { get; set; }
		public string Sku { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public double NewPrice { get; set; }
		protected bool Equals(Product other)
		{
		    return Id == other.Id && string.Equals(Name, other.Name) && 
			    string.Equals(ModelNumber, other.ModelNumber) && 
			    string.Equals(Sku, other.Sku) && string.Equals(Description, other.Description) && 
			    Price.Equals(other.Price) && NewPrice.Equals(other.NewPrice);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			return Equals((Product) obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id;
				hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (ModelNumber != null ? ModelNumber.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (Sku != null ? Sku.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ Price.GetHashCode();
				hashCode = (hashCode*397) ^ NewPrice.GetHashCode();
				return hashCode;
			}
		}
	}
