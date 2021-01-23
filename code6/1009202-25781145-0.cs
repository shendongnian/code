    public class TotalCalories : System.Web.Services.WebService
    {
        [WebMethod]
        public Food CalorieTotal(List<Food> mixedList)
        {
                ...
                aFood = CalculateItem(name, weight);
                ...
                return 
        }
        [WebMethod] //If needed to call outside of the webservice WebMethod, else just remove the attribute
        public Food CalculateItem(String name, Double weight)
        {
            ...
        }
    }
