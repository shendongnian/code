    <CheckBox Name="chkExist" Grid.Column="1" Grid.Row="0" Content="Existing settings" VerticalAlignment="Center" IsChecked="{Binding IsExistingSetting, Mode=TwoWay}"></CheckBox>
    bool isExistingSetting;
    
    public bool IsExistingSetting
    {
      get { return isExistingSetting; }
      set
      {
        if (value != isExistingSetting)
        {
         //calling one method as per my business. Method(value);
          isExistingSetting= value;
          OnPropertyChanged("IsChecked");
         }
        }
     }
     private void Method(bool isValue)
     {
      if(isValue)
      {
        // do something...
      }
      else
      {
       // do something...
      }
    }
