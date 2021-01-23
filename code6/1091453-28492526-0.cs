    var xml = @"<?xml version='1.0'?>
    <Applications>
        <Application id='1'>
            <Name>App1</Name>
        </Application>
        <Application id='2'>
            <Name>App2</Name>
        </Application>
        <Application id='3'>
            <Name>App3</Name>
        </Application>
        <Application id='4'>
            <Name>App4</Name>
        </Application>
        <Application id='5'>
            <Name>App5</Name>
        </Application>
    </Applications>";
    var doc = XDocument.Parse(xml);
