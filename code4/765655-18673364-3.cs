    <UniformGrid Columns="2">
        <ListView ItemsSource="{Binding}" HorizontalContentAlignment="Stretch">
            <ListView.View>
                <GridView AllowsColumnReorder="False">
                    <GridViewColumn Header="Item" DisplayMemberBinding="{Binding Path=Item}"/>
                    <GridViewColumn Header="Original Message" DisplayMemberBinding="{Binding OriginalMessage}"  Width="300"/>
                    <GridViewColumn Header="Translated Message" CellTemplate="{StaticResource MyDataTemplate}" />
                    <GridViewColumn Header="Sector"/>
                </GridView>
            </ListView.View>
        </ListView>
        
        <DataGrid ItemsSource="{Binding}"
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Item" Binding="{Binding Path=Item}" IsReadOnly="True"/>
                <DataGridTextColumn Header="Original Message" Binding="{Binding OriginalMessage}" IsReadOnly="True" Width="300"/>
                <DataGridTextColumn Header="Translated Message" Binding="{Binding TranslatedMessage}" />
                <DataGridTextColumn Header="Sector" Binding="{Binding Sector}"/>
            </DataGrid.Columns>
        </DataGrid>
    </UniformGrid>
