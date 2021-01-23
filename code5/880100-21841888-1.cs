     // SelectedItem attribute very important
     <ListView  
          ItemsSource="{Binding SubjectNames}" 
          SelectedItem="{Binding SelectedSubjectNames}" >
        <ListView.ItemTemplate>
            <DataTemplate>
                <WrapPanel>
                    // show a textblock with the TestsSubjectName property
                    // of TestsSubjectsNames class 
                    <TextBlock Text="{Binding TestsSubjectName}" />
                </WrapPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
     </ListView>
     
