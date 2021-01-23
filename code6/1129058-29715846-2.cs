    public class Product
        {
            private int price;
            public int Price {
                get { return price; }
                set
                {
                     price = value;
                }
            }
            public Product(string price) {
                                    try
                    {
                        this.Price = Convert.ToInt32(price);
                    }
                    catch (FormatException e)
                    {
                        throw new CustomException();
                    }
            }
        }
