        public static ExpandoObject DoWork(ExpandoObject obj)
        {
            dynamic expando = obj;
            //update price
            if (obj.Any(c => c.Key == "price"))
                expando.price = 354.11D;
            foreach (var item in expando)
            {
                if (item.Value is ExpandoObject)
                {
                    //call recursively
                    DoWork(item.Value);
                }
            }
            return expando;
        }
