        string gate_ip= NetworkGateway();
            string[] array = gate_ip.Split('.');
                          
                for (int i = 2; i <= 255; i++)
                {
                    string ping_var = array[0] +"."+array[1]+"."+array[2]+ "." + i;
                    // do scanning here
                }
