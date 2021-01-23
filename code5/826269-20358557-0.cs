     private void CourseNoTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
            {
                this.Clicked_CourseNo_Sections = (from s in Roster_Sections
                                                  where s.CourseNo.Equals(clickedSection.CourseNo)
                                                  select s).ToList();
    
                SectionsGridView.ItemsSource = Clicked_CourseNo_Sections;
            }
