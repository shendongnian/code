     string snmpClass = "SNMP_RFC1213_MIB_system";
        string path = string.Format("\\\\.\\root\\snmp\\localhost:{0}=@", snmpClass);
        
        var contextParams = new ManagementNamedValueCollection
        {
                       {"AgentAddress", "172.10.206.108"}, // ip address of snmp device
                       {"AgentReadCommunity", "public"}
        };
        
        var options = new ObjectGetOptions(contextParams);
        var objSys = new ManagementObject(new ManagementPath(path), options);
        
        Console.WriteLine(objSys.Properties["sysDescr"].Value);
        Console.ReadLine();
