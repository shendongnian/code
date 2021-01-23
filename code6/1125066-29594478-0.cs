    static class ManualIndexedProperty
    {
        public static void SetValueByCoordinates(this IBindingList list, int x, int y, object value)
        {
            object o = list[x];
            _typeToSetter[o.GetType()][y](o, value);
        }
        public static object GetValueByCoordinates(this IBindingList list, int x, int y)
        {
            object o = list[x];
            return _typeToGetter[o.GetType()][y](o);
        }
        private static readonly Dictionary<Type, Func<object, object>[]> _typeToGetter =
            new Dictionary<Type, Func<object, object>[]>()
            {
                {
                    typeof(Client),
                    new Func<object, object>[]
                    {
                        o => ((Client)o).Name
                    }
                },
                {
                    typeof(Debt),
                    new Func<object, object>[]
                    {
                        o => ((Debt)o).AccountType,
                        o => ((Debt)o).DebtValue,
                    }
                },
                {
                    typeof(Accounts),
                    new Func<object, object>[]
                    {
                        o => ((Accounts)o).Owner,
                        o => ((Accounts)o).AccountNumber,
                        o => ((Accounts)o).IsChekingAccount,
                    }
                },
            };
        private static readonly Dictionary<Type, Action<object, object>[]> _typeToSetter =
            new Dictionary<Type, Action<object, object>[]>()
            {
                {
                    typeof(Client),
                    new Action<object, object>[]
                    {
                        (o1, o2) => ((Client)o1).Name = (string)o2
                    }
                },
                {
                    typeof(Debt),
                    new Action<object, object>[]
                    {
                        (o1, o2) => ((Debt)o1).AccountType = (string)o2,
                        (o1, o2) => ((Debt)o1).DebtValue = (int)o2,
                    }
                },
                {
                    typeof(Accounts),
                    new Action<object, object>[]
                    {
                        (o1, o2) => ((Accounts)o1).Owner = (string)o2,
                        (o1, o2) => ((Accounts)o1).AccountNumber = (int)o2,
                        (o1, o2) => ((Accounts)o1).IsChekingAccount = (bool)o2,
                    }
                },
            };
    }
