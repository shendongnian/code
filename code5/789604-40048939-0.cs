        public static String TestQueueCreate(String name) {
            AmazonSQSClient sqs = new AmazonSQSClient(region: Amazon.RegionEndpoint.USEast1);
            CreateQueueResponse create = sqs.CreateQueue(name);
            Policy policy = new Policy() {
                Statements = new List<Statement>() {
                    new Statement(StatementEffect.Allow) {
                        Principals = new List<Principal>() { Principal.AllUsers },
                        Actions = new List<ActionIdentifier>() { SQSActionIdentifiers.ReceiveMessage }
                    }
                }
            };
            Dictionary<String,String> queueAttributes = new Dictionary<String, String>();
            queueAttributes.Add(QueueAttributeName.Policy.ToString(), policy.ToJson());
            sqs.SetQueueAttributes(new SetQueueAttributesRequest(create.QueueUrl, queueAttributes));
            return create.QueueUrl;
        }
