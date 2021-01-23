    private readonly ObservableCollection<Sections> currentSections = new ObservableCollection<Sections>();
    //This is what we bind to
    public ObservableCollection<Sections> CurrentSections { get { return currentSections; } }
    private void CourseNoGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      clickedSection = (Sections)e.AddedItems[0];
    }
    private void CourseNoTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
    {
      var courseSections = (from s in Roster_Sections
                      where s.CourseNo.Equals(clickedSection.CourseNo)
                      select s);
      CurrentSections.Clear();
      CurrentSections.AddRange(courseSections);
    }
