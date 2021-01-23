    protected override void PostProcessing()
    {
    	base.PostProcessing();
    
    	if (!PipelineExecuter.HasErrors)
    		Info("Process completed successfully");
    	else
    		Warn("Process failed");
    }
