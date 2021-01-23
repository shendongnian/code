	public class ElementComparer : EqualityComparer<XElement>
	{
		public override int GetHashCode(XElement xe)
		{
			return xe.Name.GetHashCode() ^ xe.Value.GetHashCode();
		}
		
		public override bool Equals(XElement xe1, XElement xe2)
		{
			var @return = xe1.Name.Equals(xe2.Name);
			if (@return)
			{
				@return = xe1.Value.Equals(xe2.Value); 
			}
			return @return;
		}
	}
