    <StackPanel>
     <CheckBox IsChecked="{Binding Path=CheckBoxValue1, Mode=TwoWay}" />
     <CheckBox IsChecked="{Binding Path=CheckBoxValue2, Mode=TwoWay}" />
     <CheckBox IsChecked="{Binding Path=CheckBoxValue3, Mode=TwoWay}" />
            
     <TextBlock>
      <TextBlock.Text>
       <Binding Path="StringValue" UpdateSourceTrigger="PropertyChanged" />
      </TextBlock.Text>
     </TextBlock>
    </StackPanel>
  
    #region properties
        string stringValue;
        public StringValue
        {
        get {return stringValue;}
        set 
        {
         stringValue = value;
         OnPropertyChanged("StringValue");
        }
          
        }
        bool checkBoxValue1;
        public bool CheckBoxValue1
        {
            get{ return checkBoxValue1; }
            set
            {
                 checkBoxValue1= value;
                 ChangedValue();
            }
        }
        bool checkBoxValue2;
        public bool CheckBoxValue2
        {
            get{ return checkBoxValue2; }
            set
            {
                 checkBoxValue2 = value;
                 ChangedValue();
            }
        }
        bool checkBoxValue3;
        public bool CheckBoxValue3
        {
            get{ return checkBoxValue3; }
            set
            {
                 checkBoxValue3 = value;
                 ChangedValue();
            }
        }
    #endregion
    
    public class myViewModel : ViewModelBase
    {
       
    
        public myViewModel( Some Parameters.... )
        {
            checkBoxValue1 = false;
            checkBoxValue2 = false;
            checkBoxValue3 = false;
            StringValue = b;
          
        }
        public void ChangedValue()
        {
          if (checkBoxValue1 && checkBoxValue2 && checkBoxValue3)
          {
              StringValue = a
          }
          else
          {
              StringValue = b
          }
        }
    }
