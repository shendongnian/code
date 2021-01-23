    public sealed class GetDefaultWorkspace : BaseActivity<Workspace>
    {     
        public override Activity CreateBody()
        {
            var type = typeof(TfGetSources).Assembly.GetType("Microsoft.TeamFoundation.Build.Activities.TeamFoundation.TfGetSources+GetDefaultWorkspaceName");
            var activity = (CodeActivity<string>)Activator.CreateInstance(type);
            var sequence = new Sequence();
            var workspaceName = new Variable<string>();
            sequence.Variables.Add(workspaceName);
            sequence.Activities.Add(activity);
            activity.Result = (OutArgument<string>) workspaceName;
            sequence.Activities.Add(new GetWorkspace
                {
                    Name = workspaceName,
                    Result = new LambdaReference<Workspace>(ctx => Result.Get(ctx))
                });
            return sequence;
        }
    }
