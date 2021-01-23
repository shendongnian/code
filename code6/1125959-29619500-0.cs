    using System;
    namespace ConsoleApplication
    {
        public static class Program
        {
            public enum OrderType
            {
                typeA,
                typeB
            }
            public class OrderTypeWrapper
            {
                private OrderType enumValue;
                public static implicit operator OrderType(OrderTypeWrapper wrapper)
                {
                    return wrapper.EnumValue;
                }
                public static implicit operator OrderTypeWrapper(OrderType ot)
                {
                    var wrapper = new OrderTypeWrapper();
                    wrapper.EnumValue = ot;
                    return wrapper;
                }
                public static implicit operator OrderTypeWrapper(String orderTypeValue)
                {
                    var wrapper = new OrderTypeWrapper();
                    wrapper.StringValue = orderTypeValue;
                    return wrapper;
                }
                public static implicit operator String(OrderTypeWrapper wrapper)
                {
                    return wrapper.StringValue;
                }
                public static implicit operator OrderTypeWrapper(int intValue)
                {
                    var wrapper = new OrderTypeWrapper();
                    wrapper.IntValue = intValue;
                    return wrapper;
                }
                public static implicit operator int(OrderTypeWrapper wrapper)
                {
                    return wrapper.IntValue;
                }
                public int IntValue
                {
                    get
                    {
                        return (int)enumValue;
                    }
                    set
                    {
                        enumValue = (OrderType)value;
                    }
                }
                public String StringValue
                {
                    get
                    {
                        return Enum.GetName(typeof(OrderType), enumValue);
                    }
                    set
                    {
                        try
                        {
                            //Use TyeParse to do something other than throw exception in presence of bad string value.
                            //Perhaps set it to an "invalid" signifying value of the enum, instead.
                            enumValue = (OrderType)Enum.Parse(typeof(OrderType), value, true); //throws exception on bad value
                        }
                        catch (ArgumentException ae)
                        {
                            var message = String.Format("Attempt to make a bad string value of \"{0}\" into an OrderType. ", value);
                            throw new Exception(message, ae);
                        }
                    }
                }
                public OrderType EnumValue
                {
                    get
                    {
                        return enumValue;
                    }
                    set
                    {
                        enumValue = value; ;
                    }
                }
            }
            public class Order
            {
                public OrderType TypeOfOrder { get; set;}
                public String StringValueOfAnOrderType { get; set; }
                public override String ToString()
                {
                    return String.Format("TypeOfOrder={0}; StringValueOfAnOrderType={1}",TypeOfOrder,StringValueOfAnOrderType);
                }
            }
            public static void Main(string[] args)
            {
                Order order = new Order();
                Order order2 = new Order();
                Order order3 = new Order();
                //straight through, not that useful but shows that wrapper can stand in
                order.TypeOfOrder = (OrderTypeWrapper)OrderType.typeB;   
                //int to string name of the enum value                
                order.StringValueOfAnOrderType = (OrderTypeWrapper)1; 
                Console.WriteLine("order: " + order);
                //string to enum value, shows that case insensitive works, see third parameter of Parse.Enum to control this.
                order2.TypeOfOrder = (OrderTypeWrapper)"TYPEB";
                //enum value to string name of the enum value
                order2.StringValueOfAnOrderType = (OrderTypeWrapper)OrderType.typeB;  
                Console.WriteLine("order2: " + order2);
                //Not that helpful as you could also cast via (OrderType), but is shows that ints work, too.
                order3.TypeOfOrder = (OrderTypeWrapper)1;                   
                //Will helpfully blow up if the string type is wrong.
                try
                {
                    order3.StringValueOfAnOrderType = (OrderTypeWrapper)"typeC";  
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception encountered: " + ex.Message);
                }
                Console.WriteLine("order3: " + order3);
                var key = Console.ReadKey();
            }
        }
    }
