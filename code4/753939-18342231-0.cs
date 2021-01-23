	public MyEntity CreateDiffEntity(MyEntity entity1, MyEntity entity2) {
		MyEntity diff = new MyEntity();
		diff.FirstName = !entity1.FirstName.equals(entity2.FirstName) ? entity2.FirstName : string.Empty;
		diff.LastName = !entity1.LastName.equals(entity2.LastName) ? entity2.LastName : string.Empty;
		return diff;
	}
