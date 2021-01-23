                svcHost = new ServiceHost(typeof(Service), eventendpoint);
                svcHost.AddServiceEndpoint(typeof(IService), new WSHttpBinding, "Endpoint");
                //Add Service Behavior
                UnderstandBehavior behavior = new UnderstandBehavior();
                svcHost.Description.Behaviors.Add(behavior);
                //////
                svcHost.Open();
                textBox1.Text = textBox1.Text + "\n\nService is Running";
                svcHost.Close();
        }
