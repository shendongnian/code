        public static List<Variance> DetailedCompare<T>(T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            FieldInfo[] fi;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            if (!val1.GetType().IsArray)
            {
                fi = val1.GetType().GetFields(BindingFlags.Instance |
                                              BindingFlags.Static |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Public);
                list1.Add(val1);
                list2.Add(val2);
            }
            else
            {
                fi = val1.GetType().GetElementType().GetFields();
                list1.AddRange(val1 as ICollection);
                list2.AddRange(val2 as ICollection);
            }
            IEnumerator en1 = list1.GetEnumerator();
            IEnumerator en2 = list2.GetEnumerator();
            while (en1.MoveNext() && en2.MoveNext())
            {
                foreach (FieldInfo f in fi)
                {
                    Variance v = new Variance();
                    v.Prop = f.Name;
                    v.valA = f.GetValue(en1.Current);
                    v.valB = f.GetValue(en2.Current);
                    if (!v.valA.Equals(v.valB))
                    {
                        DetailedCompare(v.valA, v.valB);
                        variances.Add(v);
                    }
                }
            }
            
            return variances;
        }
