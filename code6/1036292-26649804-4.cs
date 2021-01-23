    public class FruitsJuicer :IFruits
    {
        public void GetFruitJuice(Details d)
        {
            typedDataAccess da = new typedDataAccess();
            da.AddRequest(d);
        }
    }
