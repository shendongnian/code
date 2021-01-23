    public class BasketController<T>
        {
            public void AddProduct<T>(T obj)
            {
                object[] _objects;
                if (obj is AnonymousBasket)
                {
                    AnonymousBasket anon = obj as AnonymousBasket;
                    _objects = new object[] { Enumerations.BasketType.Anonymous, anon.AnonymouseBasketID, anon.PackageID, anon.PurchasedUnits };
                }
                else
                {
                    UserBasket anon = obj as UserBasket;
                    _objects = new object[] { Enumerations.BasketType.User, anon.UserID, anon.PackageID, anon.PurchasedUnits };
                }
                SqlHelper.ExecuteNonQuery(Global.ConnectionString, "Basket_Add", _objects);
            }
        }
