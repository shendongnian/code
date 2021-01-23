    var trackingParticipant = context.GetExtension<Microsoft.TeamFoundation.Build.Workflow.Tracking.BuildTrackingParticipant>();
    var warnings = GetWarnings(trackingParticipant.GetActivityTracking(context));
       
        private List<IBuildInformationNode> GetWarnings(IActivityTracking activityTracking ){
            IBuildInformationNode rootNode = getRootNode( activityTracking.Node );
            return rootNode.Children.GetNodesByType(InformationTypes.BuildWarning, true);
        }
        private IBuildInformationNode getRootNode( IBuildInformationNode  node)
        {
            while( node.Parent != null ) node = node.Parent;
            return node;
        }
