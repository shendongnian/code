        public async Task ReadFromSQS()
        {
            IAmazonSQS sqs = new AmazonSQSClient(RegionEndpoint.EUWest1);
            try
            {
                List<string> AttributesList = new List<string>();
                AttributesList.Add("NameOfTheAttribute");
                ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest();
                receiveMessageRequest.QueueUrl = IdQueue;
                receiveMessageRequest.MessageAttributeNames = AttributesList;
                ReceiveMessageResponse receiveMessageResponse = await sqs.ReceiveMessageAsync(receiveMessageRequest);
                foreach (Message message in receiveMessageResponse.Messages)
                {
                    Debug.WriteLine("Body: "+ message.Body);
                    Debug.WriteLine("Values: " + message.MessageAttributes.Count);
                    foreach (var entry in message.MessageAttributes)
                    {
                        Debug.WriteLine("Attribute");
                        Debug.WriteLine("Name: "+ entry.Key);
                        Debug.WriteLine("Value1: "+ entry.Value.StringValue);
                    }
                }
                String messageRecieptHandle = receiveMessageResponse.Messages[0].ReceiptHandle;
                //Deleting a message
                Debug.WriteLine("Deleting the message.\n");
                DeleteMessageRequest deleteRequest = new DeleteMessageRequest();
                deleteRequest.QueueUrl = IdQueue;
                deleteRequest.ReceiptHandle = messageRecieptHandle;
                await sqs.DeleteMessageAsync(deleteRequest);
            }
            catch (AmazonSQSException ex)
            {
                Debug.WriteLine("Caught Exception: " + ex.Message);
                Debug.WriteLine("Response Status Code: " + ex.StatusCode);
                Debug.WriteLine("Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Error Type: " + ex.ErrorType);
                Debug.WriteLine("Request ID: " + ex.RequestId);
            }
            Debug.WriteLine("Press Enter to continue...");
            Console.Read();
        }
