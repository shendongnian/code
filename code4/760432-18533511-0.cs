	public class ModelBase { }
	public class ModelA : ModelBase { }
	public interface IInterface<in TModel>
	{
		void Do(TModel model);
	}
	public abstract class AbstractClass<TModel> : IInterface<TModel>
	{
		public abstract void Do(TModel model);
	}
	public class ConcreteClass : AbstractClass<ModelA>, IInterface<ModelBase>
	{
		public override void Do(ModelA model)
		{
			Console.Write("Do - Override AbstractClass<ModelA> ");
		}
		void IInterface<ModelBase>.Do(ModelBase model)
		{
			Console.Write("Do - IInterface<ModelBase> ");
			Do(model as ModelA);
		}
	}
	void Main()
	{
		var modelA = new ModelA();
		(new ConcreteClass() as IInterface<ModelBase>).Do(modelA); //output -> Do - IInterface<ModelBase> Do - Override AbstractClass<ModelA> 
		Console.WriteLine();
		new ConcreteClass().Do(modelA); //output -> Do - Override AbstractClass<ModelA> 
	}
