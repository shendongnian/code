    public override Task CancelChanges()
    {
         this.SelectedWorkflow = null;
         AsyncResult<IncidentTypeModel> asyncResult =       await    this.Dataprovider.GetIncidentTypeByIdAsync(this.Incident.Id);
         if (asyncResult.IsError)
         {          WorkflowMessageBox.ShowException(MessageHelper.ManageException(asyncResult.Exception));
         }        
        else
        {
             this.Incident = asyncResult.Result;
             this.Refreshdesigner();
             this.HaveChanges = false;
         }
       });
     });
    }
