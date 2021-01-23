    if (nicname == adapter.Description)
                {
                    //Lets update all the labels to display more information about the chosen adapter.
                    label1.Text = adapter.Description;
                    label2.Text = "Name: " + adapter.Name;
                    label3.Text = "Type: " + adapter.NetworkInterfaceType;
                    label4.Text = "Status: " + adapter.OperationalStatus;
                    label5.Text = "Speed: " + adapter.Speed;
                    label6.Text = "Multicast Support? " + adapter.SupportsMulticast;
                    label7.Text = "MAC: " + adapter.GetPhysicalAddress();
                    label8.Text = "IP: ";
                    
                    //NetworkInterface[] prop = NetworkInterface.GetAllNetworkInterfaces();
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
                    {
                        label8.Text += (uniCast.Address); 
                        label10.Text = "Subnet: ";
                        //label11.Text = "IP: " +  uniCast.Address; 
                        //listBox2.Items.Add(uniCast.Address);
                        foreach (UnicastIPAddressInformation uipi in adapter.GetIPProperties().UnicastAddresses)
                        label10.Text += uipi.IPv4Mask;
                    }
                    foreach (GatewayIPAddressInformation GateWay in properties.GatewayAddresses)
                    {
                        label9.Text = "Gateway: " + GateWay.Address;
                    }
                }
