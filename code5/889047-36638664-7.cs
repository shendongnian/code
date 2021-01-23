    public class IngredientTests : TestBase
    {
        [Theory]
        [MemberData(nameof(IsValidData))]
        public void IsValid(Ingredient ingredient, string testDescription, bool expectedResult)
        {
            Assert.True(ingredient.IsValid == expectedResult, testDescription);
        }
        public static IEnumerable<object[]> IsValidData
        {
            get
            {
                var food = new Food();
                var quantity = new Quantity();
                var data= new List<ITheoryDatum>();
                
                data.Add(TheoryDatum.Factory(new Ingredient { Food = food }                       , false, "Quantity missing"));
                data.Add(TheoryDatum.Factory(new Ingredient { Quantity = quantity }               , false, "Food missing"));
                data.Add(TheoryDatum.Factory(new Ingredient { Quantity = quantity, Food = food }  , true,  "Valid"));
                return data.ConvertAll(d => d.ToParameterArray());
            }
        }
    }
