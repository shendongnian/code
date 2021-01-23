	public static class ModelStateMappings
	{
		public static Builder<M, VM> Build<M, VM>()
		{
			return new Builder<M, VM>();
		}
		
		public class Builder<M, VM>
		{
			public Builder() { }
			
			public Builder<M, VM> AddProperty<T>(
				Expression<Func<M, T>> domainMap,
				Expression<Func<VM, T>> viewModelMap)
			{
				return new BuilderProperty<M, VM, T>(this, domainMap, viewModelMap);
			}
			
			public virtual Map Create()
			{
				return new Map();
			}
		}
		
		public class BuilderProperty<M, VM, T> : Builder<M, VM>
		{
			private Builder<M, VM> _previousBuilder;
			private Expression<Func<M, T>> _domainMap;
			private Expression<Func<VM, T>> _viewModelMap;
			
			public BuilderProperty(
				Builder<M, VM> previousBuilder,
				Expression<Func<M, T>> domainMap,
				Expression<Func<VM, T>> viewModelMap)
			{
				_previousBuilder = previousBuilder;
				_domainMap = domainMap;
				_viewModelMap = viewModelMap;
			}
			
			public override Map Create()
			{
				var map = _previousBuilder.Create();
				/* code to add current map to Map class */
				return map;
			}
		}
	}
