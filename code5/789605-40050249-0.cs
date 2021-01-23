        public static String TestQueueCreate(String name) {
            AmazonSQSClient sqs = new AmazonSQSClient(region: Amazon.RegionEndpoint.USEast1);
            CreateQueueResponse create = sqs.CreateQueue(name);
            String arn = sqs.GetQueueAttributes(create.QueueUrl, new List<String>() { "QueueArn" }).Attributes["QueueArn"];
            Policy policy = new Policy() {
                Statements = new List<Statement>() {
                    new Statement(StatementEffect.Allow) {
                        Principals = new List<Principal>() { new Principal("*") },
                        Actions = new List<ActionIdentifier>() {
                            new ActionIdentifier("SQS:ReceiveMessage"),
                            new ActionIdentifier("SQS:SendMessage")
                        },
                        Resources = new List<Resource>() { new Resource(arn) }
                    }
                },
                
            };
            Dictionary<String,String> queueAttributes = new Dictionary<String, String>();
            queueAttributes.Add(QueueAttributeName.Policy.ToString(), policy.ToJson());
            sqs.SetQueueAttributes(new SetQueueAttributesRequest(create.QueueUrl, queueAttributes));
            return create.QueueUrl;
        }
