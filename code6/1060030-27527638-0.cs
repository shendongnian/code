    private static async Task CallTracking()
        {
            var client = await InboundSocket.Connect("10.10.10.36", 8021, "ClueCon");
            string uuid = null;
            client.Events.Where(x => x.EventName == EventName.ChannelAnswer)
                  .Subscribe(x =>
                      {
                          uuid = x.UUID;
                          Console.WriteLine("Channel Answer Event {0}", x.UUID);
                      });
            client.Events.Where(x => x.EventName == EventName.ChannelHangup)
                  .Subscribe(x =>
                      {
                          uuid = null;
                          Console.WriteLine("Channel Hangup Event {0}", x.UUID);
                      });
            Console.WriteLine("Press enter to hang up the current call");
            Console.ReadLine();
            if (uuid != null)
            {
                Console.WriteLine("Hanging up {0}", uuid);
                await client.Play(uuid, "ivr/8000/ivr-call_rejected.wav");
                await client.Hangup(uuid, HangupCause.CallRejected);
            }
            client.Exit();
        }
