    private static String InternalFlagsFormat(RuntimeType eT, Object value)
        {
            Contract.Requires(eT != null);
            Contract.Requires(value != null); 
            ulong result = ToUInt64(value);
            HashEntry hashEntry = GetHashEntry(eT); 
            // These values are sorted by value. Don't change this 
            String[] names = hashEntry.names;
            ulong[] values = hashEntry.values; 
            Contract.Assert(names.Length == values.Length);
            int index = values.Length - 1;
            StringBuilder retval = new StringBuilder(); 
            bool firstTime = true;
            ulong saveResult = result; 
 
            // We will not optimize this code further to keep it maintainable. There are some boundary checks that can be applied
            // to minimize the comparsions required. This code works the same for the best/worst case. In general the number of 
            // items in an enum are sufficiently small and not worth the optimization.
            while (index >= 0)
            {
                if ((index == 0) && (values[index] == 0)) 
                    break;
 
                if ((result & values[index]) == values[index]) 
                {
                    result -= values[index]; 
                    if (!firstTime)
                        retval.Insert(0, enumSeperator);
                    retval.Insert(0, names[index]); 
                    firstTime = false;
                } 
 
                index--;
            } 
            // We were unable to represent this number as a bitwise or of valid flags
            if (result != 0)
                return value.ToString(); 
            // For the case when we have zero 
            if (saveResult==0) 
            {
                if (values.Length > 0 && values[0] == 0) 
                    return names[0]; // Zero was one of the enum values.
                else
                    return "0";
            } 
            else
            return retval.ToString(); // Return the string representation 
        } 
