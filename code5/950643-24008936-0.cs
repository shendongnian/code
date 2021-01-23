     protected override void CacheMetadataInternal(System.Activities.NativeActivityMetadata metadata)
            {
                InArgument<String> workflowVersionArgument = SelectedWorkflow;
                if (workflowVersionArgument != null && workflowVersionArgument.Expression != null)
                {
                    String selectedWorkflowString = workflowVersionArgument.Expression.ToString();
                    if (selectedWorkflowString != null)
                    {
                        WorkflowVersion wfVersion = WorkflowVersion.LoadFromXML(selectedWorkflowString);
                        if (wfVersion != null && wfVersion.WorkflowName != null)
                        {
                            VersionedActivity subWorkflow = ActivityFactory.Instance.CreateActivity(wfVersion.WorkflowName, wfVersion.Version);
                            if (subWorkflow != null && subWorkflow.ActivityProp != null)
                            {
                                subWorkflowInternal = subWorkflow.ActivityProp;
                                metadata.AddImplementationChild(subWorkflowInternal);
                            }
                        }
                    }
                }
            }
