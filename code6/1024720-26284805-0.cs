        using System.Linq
        public void SetItemSourceToRandomCard()
        {
            var cardsList = new List<CardsComp>();
            cardsList.Add(card1);
            cardsList.Add(card2);
            cardsList.Add(card3);
            var myRandomCard = PickRandom(cardsList);
            listOfCardsComp.ItemsSource = new List<CardsComp> { myRandomCard };
        }
        public T PickRandom<T>(IEnumerable<T> objects)
        {
            var randomItemIndex = new Random().Next(objects.Count());
            return (T)objects.ElementAt(randomItemIndex);
        }
