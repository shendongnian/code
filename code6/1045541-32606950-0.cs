    public class SmartModelBuilder<T> where T : class         {
      
        private ModelBuilder _builder { get; set; }
        private Action<EntityTypeBuilder<T>> _entityAction { get; set; }
        public SmartModelBuilder(ModelBuilder builder, Action<EntityTypeBuilder<T>> entityAction)
        {
            this._builder = builder;
            this._entityAction = entityAction;
            this._builder.Entity<T>(_entityAction);
        }
    }     
