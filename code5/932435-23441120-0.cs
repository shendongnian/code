            // Bind to the existing task by using the ItemId.
            // This method call results in a GetItem call to EWS.
            Task task = Task.Bind(service, itemId);
            // Update the Status of the task.
            task.Status = TaskStatus.Completed;
            // Save the updated task.
            // This method call results in an UpdateItem call to EWS.
            task.Update(ConflictResolutionMode.AlwaysOverwrite);
