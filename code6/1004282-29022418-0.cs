    public class ViewTest : BindableBase
    {
        public long SortOrder { get; set; }
    }
    private ObservableCollection<ViewTest> testViewList = new ObservableCollection<ViewTest>();
    public ObservableCollection<ViewTest> TestViewList
    {
        get { return this.testViewList; }
        private set { this.SetProperty<ObservableCollection<ViewTest>>(ref this.testViewList, value); }
    }
    <ListView ItemsSource="{Binding Path=TestViewList, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Order" DisplayMemberBinding="{Binding Path=SortOrder}" />
            </GridView>
        </ListView.View>
    </ListView>
    private void AddTest(string test)
    {
        ViewTest newTest = new ViewTest();
        newTest.SortOrder = this.GetHighestSortOrder(this.TestViewList) + 1;
        this.TestViewList.Add(newTest);
    }
    private int GetHighestSortOrder(ObservableCollection<ViewTest> testList)
    {
        int highest = 0;
        foreach (ViewTest test in testList)
        {
            if (test.SortOrder > highest)
            {
                highest = Convert.ToInt32(test.SortOrder);
            }
        }
        return highest;
    }
    private ObservableCollection<ViewTest> SortTests(ObservableCollection<ViewTest> testList)
    {
        ObservableCollection<ViewTest> sortedList = new ObservableCollection<ViewTest>();
        while (testList.Count > 0)
        {
            int index = 0;
            int lowest = 0;
            while (index < testList.Count)
            {
                if (testList[index].SortOrder < testList[lowest].SortOrder)
                {
                    lowest = index;
                }
                index += 1;
            }
            sortedList.Add(testList[lowest]);
            testList.RemoveAt(lowest);
        }
        return sortedList;
    }
