    <dxe:TextEdit Margin="89,116,69,123" x:Name="txtFilter" Background="AliceBlue" >
        <dxmvvm:Interaction.Behaviors> 
            <dxmvvm:EventToCommand EventName="EditValueChanged" Command="{Binding FilterCommand}"
                CommandParameter="{Binding ElementName=txtFilter, Path=Text}"/> 
        </dxmvvm:Interaction.Behaviors> 
    ...
    [POCOViewModel]
    public class CoolectionViewModel {
        [Command]
        public void Filter(string searchText) {
            ...
        }
    }
    
