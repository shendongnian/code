    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Person> hungryPeople = new List<Person>();
            foreach (Person person in value as List<Person>)
                if (person.isHungry)
                    hungryPeople.Add(person);
            return hungryPeople;
        }
    }
