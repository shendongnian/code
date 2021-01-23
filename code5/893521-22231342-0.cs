    <Grid x:Name="ContentPanel" Grid.Row="1" Margin="12,0,12,0">
        <Grid.Resources>
            <Color x:Key="CommentColor">#FFEC4521</Color>
            <SolidColorBrush x:Key="CommentColorBrush" Color="{StaticResource CommentColor}"></SolidColorBrush>
        </Grid.Resources>
        <StackPanel>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition Width="Auto" />
                </Grid.ColumnDefinitions>
                <RichTextBox IsReadOnly="True" Background="{StaticResource CommentColorBrush}" Padding="6">
                    <Paragraph>
                        <Run Text="You are so funny!"/>
                        <InlineUIContainer>
                            <Image Source="/Assets/happy.png" Height="16"></Image>
                        </InlineUIContainer>
                    </Paragraph>
                </RichTextBox>
                <TextBlock Grid.Column="2" VerticalAlignment="Center">Michael</TextBlock>
            </Grid>
        </StackPanel>
    </Grid>
