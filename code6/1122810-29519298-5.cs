    <?xml version="1.0" encoding="utf-8"?>
    <MappingsXml xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <Mappings>
        <RemoteMappingFile SSISName="ssis1.dtsx">
          <RemoteMappings>
            <RemoteMapping>
              <TableNames Source="sourceTable1" Destination="destinationTable1" />
              <Columns>
                <Column Source="sourceColumn1" Destination="destinationColumn1" />
                <Column Source="sourceColumn2" Destination="destinationColumn2" />
              </Columns>
            </RemoteMapping>
            <RemoteMapping>
              <TableNames Source="sourceTable2" Destination="destinationTable2" />
              <Columns>
                <Column Source="sourceColumn3" Destination="destinationColumn3" />
                <Column Source="sourceColumn4" Destination="destinationColumn4" />
              </Columns>
            </RemoteMapping>
          </RemoteMappings>
        </RemoteMappingFile>
      </Mappings>
    </MappingsXml>
