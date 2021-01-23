    <?xml version="1.0" encoding="utf-8"?>
    <Elements xmlns="http://schemas.microsoft.com/sharepoint/">
      <Receivers ListUrl="Lists/ExternalDisplay">
          <Receiver>
            <Name>ExternalTestItemAdding</Name>
            <Type>ItemAdding</Type>
            <Assembly>$SharePoint.Project.AssemblyFullName$</Assembly>
            <Class>SOEventReceiver.ExternalTest.ExternalTest</Class>
            <SequenceNumber>10000</SequenceNumber>
          </Receiver>
          <Receiver>
            <Name>ExternalTestItemUpdating</Name>
            <Type>ItemUpdating</Type>
            <Assembly>$SharePoint.Project.AssemblyFullName$</Assembly>
            <Class>SOEventReceiver.ExternalTest.ExternalTest</Class>
            <SequenceNumber>10000</SequenceNumber>
          </Receiver>
      </Receivers>
    </Elements>
