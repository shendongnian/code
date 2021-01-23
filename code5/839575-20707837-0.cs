    private void btnVegetarian_Click(object sender, RoutedEventArgs e)
    {
        Filer(MealCategory.Vegatarian).Invoke();
    }
    
    private void btnMeat_Click(object sender, RoutedEventArgs e)
    {
        Filer(MealCategory.Meat).Invoke();
    }
    
    private void btnFish_Click(object sender, RoutedEventArgs e)
    {
       Filer(MealCategory.Fish).Invoke();
    }
    public Action Filer(MealCategory mealCategory)
     {
        lbxMeals.ItemsSource = new ObservableCollection<Meal>(meals.Where(m=>m.Category=mealCategory))
      }
