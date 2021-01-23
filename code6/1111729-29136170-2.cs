        public struct Test
        {
            public int m_nObj;
            public object[] array;
        }
        ....
         Test[]  pTest = new Test[1000000];
         for(int i = 0 ; i <  1000000; i++)
         {
             pTest[i].array = new object[10];
         }
