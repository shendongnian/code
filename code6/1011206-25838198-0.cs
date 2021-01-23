    namespace MyProgram
    {
        public class BaseEntity {}    
        public class CountryDLL<TEntity> {}    
        public class MainObjDLL<TEntity> {}    
        public interface IBaseBLL<out TEntity> {}    
        public class MainObj: BaseEntity {}    
        public class Country : MainObj {}    
        public class CountryBLL<TEntity> : CountryDLL<TEntity>,IBaseBLL<TEntity> where TEntity : Country {}    
        public class MainObjBLL<TEntity> : MainObjDLL<TEntity>, IBaseBLL<TEntity> where TEntity : MainObj {}    
        
        class Program
        {    
            public static IBaseBLL<T> GetProperBllFromObjName<T>(string entityName)
            { 
                IBaseBLL<T> baseBLL = null;
                switch (entityName)
                { 
                    case "Country":
                        CountryBLL<Country> aa = new CountryBLL<Country>(); 
                        baseBLL = (IBaseBLL<T>) aa; //error line
                        break;
                }
        
                return baseBLL;
            }
            
            static void Main()
            {
                IBaseBLL<Country> c = GetProperBllFromObjName<Country>("Country");
                IBaseBLL<BaseEntity> d = GetProperBllFromObjName<BaseEntity>("Country");
            }
        }
    }
