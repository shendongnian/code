	<DataGrid x:Name="dataGrid_XML" AutoGenerateColumns="false">
		<DataGrid.Columns>
			<DataGridTextColumn Binding="{Binding patientID}"  Header="ID Patient" IsReadOnly="True"/>
			<DataGridTextColumn Binding="{Binding genre}"  Header="Genre" IsReadOnly="True"/>
			<DataGridTextColumn Binding="{Binding createDate}"  Header="Date création" IsReadOnly="True"/>
			<DataGridTextColumn Binding="{Binding typeData}"  Header="Type de données" IsReadOnly="True"/>
			<DataGridTextColumn Binding="{Binding actionData}"  Header="Date de dernière action" IsReadOnly="True"/>
		</DataGrid.Columns>        
	</DataGrid>
      
