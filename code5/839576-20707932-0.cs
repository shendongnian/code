    private void btnMeat_Click(object sender, RoutedEventArgs e)
    {
        lbxMeals.ItemsSource = meals.Where(m => m.Category == MealCategory.Meat)
                                    .ToList();
    }
