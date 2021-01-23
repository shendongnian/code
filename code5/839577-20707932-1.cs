    private void btnMeat_Click(object sender, RoutedEventArgs e)
    {
        lbxMeals.ItemsSource = new ObservableCollection<Meal>(
                                  meals.Where(m => m.Category == MealCategory.Meat));
    }
