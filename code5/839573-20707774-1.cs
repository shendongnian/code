    private void btnVegetarian_Click(object sender, RoutedEventArgs e)
    {
        FilterMeals(MealCategory.Vegatarian);
    }
    private void btnMeat_Click(object sender, RoutedEventArgs e)
    {
        FilterMeals(MealCategory.Meat);
    }
    private void btnFish_Click(object sender, RoutedEventArgs e)
    {
       FilterMeals(MealCategory.Fish);
    }
    private void FilterMeals(MealCategory category)
    {
        filteredMeals = new ObservableCollection<Meal>();
        Meal newMeal = new Meal();
        for (int i = 0; i < meals.Count; i++)
        {
            newMeal = meals[i];
            if (newMeal.Category == category)
            {
                filteredMeals.Add(newMeal);
            }
        }
        lbxMeals.ItemsSource = filteredMeals;
    }
