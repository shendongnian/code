     interface Interface1
        {
            void Authorize(string p1, int p2);
            void LookupCode(int test);
            void GetObject(int ID);
        }
    
        interface Interface2
        {
            void Authorize(string p1);
            void LookupCode(int test);
            void GetObject(int ID);
        }
    
        class WebService : Interface1, Interface2
        {
            public void Authorize(string p1, int p2)
            {
                throw new NotImplementedException();
            }
    
            public void Authorize(string p1)
            {
                throw new NotImplementedException();
            }
    
            void Interface2.LookupCode(int test)
            {
                throw new NotImplementedException();
            }
    
            void Interface2.GetObject(int ID)
            {
                throw new NotImplementedException();
            }
    
            void Interface1.LookupCode(int test)
            {
                throw new NotImplementedException();
            }
    
            void Interface1.GetObject(int ID)
            {
                throw new NotImplementedException();
            }
        } 
