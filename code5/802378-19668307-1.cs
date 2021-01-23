    <DataGridTemplateColumn Header="Category">
    	<DataGridTemplateColumn.CellTemplate>
    		<DataTemplate>
    			<Button x:Name="categoryButton" Style="{StaticResource Flat}" Tag="{Binding Category}"
    						Command="{Binding Path=DataContext.SelectCategoryCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}, UpdateSourceTrigger=PropertyChanged}"
    						CommandParameter="{Binding ElementName=categoryButton, Path=Tag}">
    				<Image Source="{Binding Category, Converter={StaticResource categoryConverter}}"/>
    			</Button>
    		</DataTemplate>
    	</DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
