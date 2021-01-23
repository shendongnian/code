    foreach (XmlNode node in nodeList)
            {
                XmlNodeList nodeListAudio = node.SelectNodes("//pt:Actions", nsmgr);           
                Patient patient = new Patient(node["pt:NOAHPatientId"].InnerText, node["pt:Gender"].InnerText, node["pt:CreateDate"].InnerText);
                dataGrid_XML.Items.Add(patient);
                foreach (XmlNode nodeAudio in nodeListAudio)
                {
                    Audiogram audiogramme = new Audiogram(nodeAudio["pt:TypeOfData"].InnerText, nodeAudio["pt:ActionDate"].InnerText);                   
                    dataGrid_XML.Items.Add(audiogramme);
                }              
            }
            <DataGrid x:Name="dataGrid_XML" AutoGenerateColumns="false">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding patientID}"  Header="ID Patient" IsReadOnly="True"/>
                <DataGridTextColumn Binding="{Binding genre}"  Header="Genre" IsReadOnly="True"/>
                <DataGridTextColumn Binding="{Binding createDate}"  Header="Date création" IsReadOnly="True"/>
                <DataGridTextColumn Binding="{Binding typeData}"  Header="Type de données" IsReadOnly="True"/>
                <DataGridTextColumn Binding="{Binding actionData}"  Header="Date de dernière action" IsReadOnly="True"/>
            </DataGrid.Columns>        
        </DataGrid>
        
