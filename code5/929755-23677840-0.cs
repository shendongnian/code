    public class NPISNote
    {
      // properties
    }
    
    public class NPISItem
    {
      public ObservableCollection<NPISNoteBO> Notes { get; set; }
    }
    
    public class ViewModel
    {
      public ObservableCollection<NPISItemBO> NPISItemsList { get; set; }
    }
    
    <telerik:RadGridView ItemsSource={Binding NPISItemsList, Source={StaticResource NPISViewModel}}>
     // columns
      <telerik:RadGridView.RowDetailsTemplate>
        <DataTemplate> 
          <telerik:RadGridView ItemsSource={Binding Notes}>
            // columns
          </telerik:RadGridView>
        </DataTemplate> 
      </telerik:RadGridView.RowDetailsTemplate>
    </telerik:RadGridView>
