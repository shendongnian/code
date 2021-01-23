        public static int[,] TablaContingencia(MAnalitica[] M)
        {
          int[,] TablaContingencia = new int[2, 2]; //Inicializes with size 2x2
          int categ = M.GetLength(0);
          for (int m = 0; m <= categ - 1; m = m + 1)
          {
            int k = M[m].P;
            int Pr0 = Convert.ToInt16(M[m].Conteo * (1 - M[m].PCliente));
            int Pr1 = Convert.ToInt16(M[m].Conteo * M[m].PCliente);
            TablaContingencia[k, 0] = TablaContingencia[k, 0] + Pr0;
            TablaContingencia[k, 1] = TablaContingencia[k, 1] + Pr1;
           }
           return TablaContingencia;
       }
