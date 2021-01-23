    public class Meal : INotifyPropertyChanged
    {
        public List<MealPart> MealParts { get;set; }
        public MealPart SelectedMealPart {
            get { return _selected;  }
            set { _selected = value;
                 // Implement INotifyPropertyChanged and fire the event here
            }
        }
    }
