     using (CalculatorClient client = new CalculatorClient())
            {
                // Call Divide and catch the associated Exception.  This throws because the
                // server aborts the channel before returning a reply.
                try
                {
                    client.Divide(0.0, 0.0);
                }
                catch (CommunicationException e)
                {
                    Console.WriteLine("Got {0} from Divide.", e.GetType());
                }
            }
