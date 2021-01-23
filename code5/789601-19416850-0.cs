            // 4. Set the queue policy to allow SNS to publish messages
            ActionIdentifier[] actions = new ActionIdentifier[2];
            actions[0] = SQSActionIdentifiers.SendMessage;
            actions[1] = SQSActionIdentifiers.ReceiveMessage;
            Policy sqsPolicy = new Policy()
                .WithStatements(new Statement(Statement.StatementEffect.Allow)
                                    .WithPrincipals(Principal.AllUsers)
                                    .WithResources(new Resource(queueArn))
                                    .WithConditions(ConditionFactory.NewSourceArnCondition(_AWSSNSArn))
                                    .WithActionIdentifiers(actions));
            SetQueueAttributesRequest setQueueAttributesRequest = new SetQueueAttributesRequest();
            List<Amazon.SQS.Model.Attribute> attributes = new List<Amazon.SQS.Model.Attribute>();
            Amazon.SQS.Model.Attribute attribute = new Amazon.SQS.Model.Attribute();
            attribute.Name = "Policy";
            attribute.Value = sqsPolicy.ToJson();
            attributes.Add(attribute);
            setQueueAttributesRequest.QueueUrl = queueUrl;
            setQueueAttributesRequest.Attribute = attributes;
            sqs.SetQueueAttributes(setQueueAttributesRequest);
