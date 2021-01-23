      wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                Debug.WriteLine("Workflow completed.");
                Debug.WriteLine("State" + e.CompletionState);
                if (e.CompletionState == ActivityInstanceState.Closed)
                {
                    _caseIsCompleted = true;
                }
            };
