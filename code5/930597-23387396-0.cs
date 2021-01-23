    const string machinesXml = @"<XMLFILE>
        <Machines>
            <Alias name=""MACHINE_AAA_1"" />
            <Alias name=""MACHINE_AAA_2"" />
            <Alias name=""MACHINE_AAA_3"" />
            <Alias name=""MACHINE_BBB_1"" />
            <Alias name=""MACHINE_BBB_2"" />
            <Alias name=""MACHINE_BBB_3"" />
            <Alias name=""MACHINE_CCC_1"" />
            <Alias name=""MACHINE_CCC_2"" />
            <Alias name=""MACHINE_DDD_1"" />
        </Machines>
    </XMLFILE>";
    
    var XEle = XElement.Parse(machinesXml);
    
    // Locate the machines element
    var machinesElement = XEle.Element("Machines");
    
    // Split the name
    var splitAliasNames = machinesElement.Elements("Alias").Select(a => a.Attribute("name").Value.Split('_'));
    
    // Only take those where the split elements are what we expect
    var ofCorrectParts = splitAliasNames.Where(split => split.Length == 3 &&
    										"MACHINE".Equals(split[0], StringComparison.OrdinalIgnoreCase));
    
    var channelForMachine = ofCorrectParts.Select(split => new
    {
        MachineName = split[1], 
        ChannelName = split[2]
    });
    
    var byMachineName = channelForMachine.GroupBy(s => s.MachineName, StringComparer.OrdinalIgnoreCase);
    var machines = byMachineName.Select(g =>
        {
            var channels = g.Select(s => s.ChannelName).ToList();
            return new Machine
            {
                Name = g.Key,
                Channels = channels
            };
        });
    
    foreach (var machine in machines)
    {
        Console.WriteLine("Machine '{0}':", machine.Name);
        foreach (var channel in machine.Channels)
        {
            Console.WriteLine("\tChannel '{0}'", channel);
        }
    }
    Console.ReadKey(true);
