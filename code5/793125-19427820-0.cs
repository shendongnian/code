    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Person> hungryPeople = value as List<Person>();
            foreach (Person person in People)
                if (person.isHungry)
                    hungryPeople.Add(person);
            return hungryPeople;
        }
    }
