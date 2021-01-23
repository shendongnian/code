        void OnApplicationStarted(UmbracoApplicationBase app, ApplicationContext ctx)
        {
            ExamineManager.Instance
                          .IndexProviderCollection["ExternalIndexer"]
                          .GatheringNodeData += OnGatheringNodeData;
        }
