    [Serializable]
    public class CombinedAspect : MethodLevelAspect, IAspectProvider
    {
        private int count = 0;
        public IEnumerable<AspectInstance> ProvideAspects( object targetElement )
        {
            IAspectRepositoryService repositoryService = PostSharpEnvironment.CurrentProject.GetService<IAspectRepositoryService>();
            if ( !repositoryService.HasAspect( targetElement, typeof(FirstAspect) ) )
                yield return new AspectInstance( targetElement, new FirstAspect() );
            if ( !repositoryService.HasAspect( targetElement, typeof(SecondAspect) ) )
                yield return new AspectInstance( targetElement, new SecondAspect() );
        }
    }
