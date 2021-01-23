        const int DIM0 = 4000;
        const int DIM2 = 7000;
        const int DIM3 = 4;
        int[, ,] array = new int[DIM0 , DIM2 , DIM3 ];
        void writeArray(string fileName)
        {
            StringBuilder SB = new StringBuilder();
            for (int k=0; k < DIM2 ; k++)
            for (int j=0; j < DIM1 ; j++)
            for (int i=0; i < DIM0 ; i++)
            {
                if (array[i,j,k] != 0)
                    SB.Append(String.Format("{0},{1},{2},{3};",i,j,k,array[i,j,k]) );
            }
            File.WriteAllText(fileName, SB.ToString().TrimEnd(';') );
        }
        void readArray(string fileName)
        {
            string s = File.ReadAllText(fileName);
            string[] p = s.Split(';');
            bool error = false;
            foreach (string e in p)
            {
                string[] n = e.Split(',');
                int i = 0; int j = 0; int k = 0; int v = 0;
                error  = !Int32.TryParse(n[0], out i) ;
                error &= !Int32.TryParse(n[1], out j);
                error &= !Int32.TryParse(n[2], out k);
                error &= !Int32.TryParse(n[3], out v);
                if (!error) array[i, j, k] = v;
                else { /*abort with error message..*/}
            }
        }
