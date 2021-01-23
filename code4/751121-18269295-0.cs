    <CheckBox BorderThickness="2" **Loaded="OnLoaded"**
                              VerticalAlignment="Center" 
                              x:Name="TemplateCheckBox" 
                              IsChecked="{Binding IsDone, UpdateSourceTrigger=Explicit, Mode=TwoWay}"
                              Checked="TemplateCheckBox_Checked"
                              Unchecked="TemplateCheckBox_Checked"
                              />
    
    private List<CheckBox> chkList=new List<CheckBox>();
    
    private void OnLoaded(object sender,EventArgs e)
    {
       if(!chkList.Contians(sender as CheckBox))
       {
         chkList.Add(sender as CheckBox);
       }
    }
    
    private void UpdateSource()
    {
       foreach(CheckBox chk in chkList)
       {
         chk.GetBindingExpression(CheckBox.IsChekcedProperty).UpdateSource();
       }
    }
