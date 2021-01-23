        public T getval()
        {
            if(_no is IConvertible) //could also be put in the generic constraint for <T>
            {
                //use decimal for the largest precision, 
                var dec = Convert.ToDecimal(_no); //will throw an exception if not numeric
                if (dec < 0) 
                {
                    return (T)Convert.ChangeType(-dec, typeof(T));
                }
            }
            return _no;        
        }
