	public sealed class CustomActivity : CodeActivity
	{
		protected override void Execute(CodeActivityContext context)
		{
			// get workspace
			var buildDetail = context.GetExtension<IBuildDetail>();
			var buildAgent = context.GetExtension<IBuildAgent>();
			var buildDirectory = buildAgent.GetExpandedBuildDirectory(buildDetail.BuildDefinition);
			var workspacePath = Path.Combine(buildDirectory, "src");
			var wsInfo = Workstation.Current.GetLocalWorkspaceInfo(workspacePath);
			var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(wsInfo.ServerUri);
			tfs.Connect(ConnectOptions.None);
			var vcs = tfs.GetService<VersionControlServer>();
			// finally can get to the workspace here
			var workspace = vcs.GetWorkspace(workspacePath);
		}
	}
