        //... Other stuff
        public BaseClass SimpleClone()
        {
            var result = new DerivedClass 
                             {
                                 Value1 = this.Value1,
                                 Value2 = this.Value2,
                                 Value3 = this.Value3,
                             }
            return result;
        }
