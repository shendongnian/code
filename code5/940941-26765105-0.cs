    <ScrollViewer Margin="5">
        <StackPanel Orientation="Vertical">
            <ItemsControl ItemsSource="{Binding AllTeachers}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <TextBlock>
                                <Run Text="{Binding TeacherName}"/>
                                <Run Text="{Binding TeacherSurname}"/>
                        </TextBlock>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        <Button Content="Add teacher"/>                    
        </StackPanel>
    </ScrollViewer>
