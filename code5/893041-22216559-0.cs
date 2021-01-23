    public  List<object> differentVarColl = new List<object>();
        void MethodA()
        {
            int a = 0;
            int b = 10;
            double c = -90;
            DataTable dtData = new DataTable();
            //Do rest of things
            differentVarColl.Add(a);
            differentVarColl.Add(b);
            differentVarColl.Add(c);
            differentVarColl.Add(dtData);
        
        }
        
