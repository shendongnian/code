    <ListBox ItemsSource={Binding Files} SelectedItem={Binding SelectedFileDTO, Mode=TwoWay}/>
    
    public FilesDTO SelectedFileDTO
    {
       get...
       set...
    }
