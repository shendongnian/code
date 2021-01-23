    public interface IDataTransformerSelector<TModel, TContext>
        where TContext : OpenAccessContext, new()
    {
        IEnumerable<IDataTransformer<TContext>> 
            SelectTransformers(IEnumerable<IDataTransformer<TContext>> allTransformers);
    }
    public class DataTransformerSelector<TModel, TContext> :
        IDataTransformerSelector<TModel, TContext>
        where TContext : OpenAccessContext, new()
    {
        public IEnumerable<IDataTransformer<TContext>> 
            SelectTransformers(IEnumerable<IDataTransformer<TContext>> allTransformers)
        {
            // Custom logic to map the model type to the transformers that apply
            if (typeof(TModel) == typeof(NormalModel))
            {
                return allTransformers.Where(transformer =>
                    transformer.GetType() == typeof(TrackCreatedTransformer) ||
                    transformer.GetType() == typeof(TrackChangedTransformer)).ToArray();
            }
            
            if (typeof(TModel) == typeof(SpecialModel))
            {
                return allTransformers.Where(transformer =>
                    transformer.GetType() == typeof(TrackCreatedTransformer) ||
                    transformer.GetType() == typeof(TrackChangedTransformer) ||
                    transformer.GetType() == typeof(TrackClosedTransformer)).ToArray();
            }
            
            if (typeof (TModel) == typeof (AnotherModel))
            {
                return allTransformers.Where(transformer =>
                    transformer.GetType() == typeof (TrackCreatedTransformer) ||
                    transformer.GetType() == typeof (TrackChangedTransformer) ||
                    transformer.GetType() == typeof (TrackClosedTransformer) ||
                    transformer.GetType() == typeof (TrackSignedTransformer)).ToArray();
            }
            throw new InvalidOperationException("Unknown model type: " + typeof(TModel));
        }
    }
