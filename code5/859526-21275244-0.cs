    <ListBox x:name = "TheList"  ItemSource ="{Binding List}" SelectionChanged="SelectionChanged_1">
       <DataTemplate>
         <TextBlock Text = "{Binding Name}" Tap="txtBlock_Tap" />
          <Image ImageSource = "{Binding Picture}" Tap="img_Tap"/>
          <StackPanel>
           <\StackPanel>
        <\DataTemplate>
    </ListBox>
                
     private void txtBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
          MessageBox.Show("TextBlock click");
          var item = TheList.SelectedItem as your Type;
         }
                
     private void img_Tap(object sender, System.Windows.Input.GestureEventArgs e)
         {
           MessageBox.Show("Image click");
           var item = TheList.SelectedItem as your Type;
         }
