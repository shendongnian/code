	public abstract class MyEntitiesA<TPrimKey> : Entities<TPrimKey>
	{
		// Methods that apply to all TPrimKeys go here.
		// Some methods may need to be abstract, and implemented
		// in each subclass, that has a concrete key (or at least a key with a constraint).
	}
	public class MyEntities : MyEntitiesA<int>
    ...
