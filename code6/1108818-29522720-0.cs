     var commit = new OffsetCommitRequest
                {
                    ConsumerGroup = consumerGroup,
                    OffsetCommits = new List<OffsetCommit>
                                {
                                    new OffsetCommit
                                        {
                                            PartitionId = partitionId,
                                            Topic = IntegrationConfig.IntegrationTopic,
                                            Offset = offset,
                                            Metadata = metadata
                                        }
                                }
                };
    
    var commitResponse = conn.Connection.SendAsync(commit).Result.FirstOrDefault();
