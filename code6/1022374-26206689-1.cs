    public List<Type> Types {get;set;}
    public Type SelectedType {get;set;}
    <ComboBox ItemsSource="{Binding Types}" 
              SelectedItem="{Binding SelectedType}" 
              DisplayMemberPath="Name" />
