    private async void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    var DLQPath = "/$DeadLetterQueue"; ///**** Important - Pointing to DLQ'
    
                    var topicName = "message";
                    var sub = "message-subscription";
                    int batchSize = 100;
    
                    runProcess = true;
    
                    _subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionSt, topicName, sub + DLQPath, ReceiveMode.ReceiveAndDelete);
    
                    int cnt = 0;
    
                    do
                    {
                        var messages = await _subscriptionClient.ReceiveBatchAsync(batchSize);
                        var msgCount = messages.Count();
    
                        if (msgCount == 0)
                        {
                            break;
                        }
                        cnt += msgCount;
                        labelCount.Text = cnt.ToString();
                    }
                    while (runProcess);
    
                    _subscriptionClient.Close();
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                    return;
                }
            }
