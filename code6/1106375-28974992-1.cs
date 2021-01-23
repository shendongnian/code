    private void OnJobTimedEvent(object sender, ElapsedEventArgs e)
    {
    	UploadJob job;
    	if (_jobQueue.TryDequeue(out job)) // Returns false if it fails to return the next object from the queue
    	{
    		if (Class1.UploadPost(job.Group,
    			job.Name,
    			job.Message,
    			job.Caption,
    			job.Link,
    			job.Description,
    			job.Picture) != string.Empty)
    		{
    			// Post was uploaded successfully
    		}
    	}
    	else
    	{
    		// I believe we can assume that the job queue is empty.
    		// I'm not sure about the conditions under which TryDequeue will fail
    		// but if "no more elements" isn't the only one, we could add
    		// (_jobQueue.Count == 0)
    		// to the if statement above
    		_jobTimer.Stop();
    		// All uploads complete
    	}
    }
