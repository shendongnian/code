    public class RepoFactories
    {
	    public static IRepoFactory GetFactory(string typeOfFactory)
	    {
	        return (IRepoFactory)Activator.CreateInstance(Type.GetTypetypeOfFactory)
	    }
    }
