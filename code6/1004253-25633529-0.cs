        public class FoodService()
        {
            public void WriteRecommendedFood(IList<Food> foodList, IFoodFormatter formatter)
            {
                using (StreamWriter sw = new StreamWriter("file.csv", false)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Food f in foodList)
                    {
                       sw.WriteLine(foodformatter.Format(f));
                    }
                    sw.Close();
                }
            }
        }
        interface IFoodFormatter
        {
            string Format(Food f);
        }
