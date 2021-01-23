        public object[] GetSomeArray()
        {
            return new object[] { 5, 2, 1, 7, 9, 1, 5, 7 };
        }
        public double[] ArraySorted(object tablica)
        {
            object[] obj = (object[])tablica;
            var filtr = from i in obj
                        orderby Convert.ToDouble(i)
                        select Convert.ToDouble(i);
            double[] wynik = (double[])filtr.ToArray();
            return wynik;
        }
