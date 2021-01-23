    public class ConcreteClass : AbstractClass<ModelA>, IInterface<ModelBase>
    {
        public override void Do(ModelA modelA) // change 'model' into 'modelA'
        {
            // I'd like to invoke this method
        }
    
        public void Do(ModelBase model)
        {
            // how do I invoke the method above??
            Do(modelA : (ModelA)model);
        }
    }
