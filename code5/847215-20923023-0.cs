    foreach (var Stats in player){
    var columnHeaderScore = new TextBlock
    {
        Style = Application.Current.Resources["Column_Value_Large"] as Style,
    };
    columnHeaderScore.SetBinding(TextBlock.TextProperty, new Binding
    {
        Source = Stats.Scores.Team,
    });
    columnHeaderStackPanel.Children.Add(columnHeaderScore);
}
