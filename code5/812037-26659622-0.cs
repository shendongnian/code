    <?xml version="1.0" encoding="utf-8"?>
    <Elements xmlns="http://schemas.microsoft.com/sharepoint/">
      <Receivers ListUrl="Lists/MyList"> <!-- ====== Modify accordingly ===== -->
          <Receiver>
            <Name>CampagnasListEventReceiverListAdded</Name>
            <Type>ListAdded</Type>
            <Assembly>$SharePoint.Project.AssemblyFullName$</Assembly>
            <Class>{Class Namespace}</Class>
            <SequenceNumber>10000</SequenceNumber>
          </Receiver>
      </Receivers>
    </Elements>
