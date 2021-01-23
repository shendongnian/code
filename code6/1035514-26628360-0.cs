    <StackPanel>
        <CheckBox Content="Show comment" Name="CommentCheckBox"/>
        <TextBox Text="{Binding Comment, UpdateSourceTrigger=PropertyChanged}" Name="CommentTextBox">
            <TextBox.Style>
                <Style TargetType="{x:Type TextBox}">
                    <Setter Property="Visibility" Value="Hidden"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=CommentCheckBox, Path=IsChecked}" Value="True">
                            <Setter Property="Visibility" Value="Visible"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
    </StackPanel>
