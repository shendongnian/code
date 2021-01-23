    public IEnumerable<MyItem> ReportsWithAnwers
    {
        get
        {
           return Reports.Where(x => x.CountAnswers > 0);
        }
    }
    <ListBox Name="QuestionList" ItemsSource="{Binding ReportsWithAnwers}">
        <ListBox.ItemTemplate>
            <DataTemplate >            
                 <TextBlock Text="{Binding CountAnswers}"/>                      
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
