	public static class Extensions
	{
		public static Dino AsDino(this string name)
		{
			return new Dino() {Value=name};
		}
		public static Dino AsDino(this string name, object[] reference, int parentIndex)
		{
			return new Dino() {Value=name, Parent=reference, ParentIndex=parentIndex };
		}
		public static Dino Replace(this object item, Dino replacementItem)
		{
			replacementItem.ParentIndex=((Dino)item).ParentIndex;
			replacementItem.Parent=((Dino)item).Parent;
			((Dino)item).Parent[replacementItem.ParentIndex]=replacementItem;
			return replacementItem;
		}
	}
