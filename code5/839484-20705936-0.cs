    int[,] joinedMatrice = new int[matrice0.GetLength(0) + matrice1.GetLength(0), matrice0.GetLength(1) + matrice2.GetLength(1)];
        for (int i = 0; i < matrice0.GetLength(0) + matrice1.GetLength(0); i++)
        {
            for (int j = 0; j < matrice0.GetLength(1) + matrice2.GetLength(1); j++)
            {
                int value = 0;
                if (i < matrice0.GetLength(0) && j < matrice0.GetLength(1))
                {
                    value = matrice0[i, j];
                }
                else if (i >= matrice0.GetLength(0) && j < matrice0.GetLength(1))
                {
                    value = matrice1[i - matrice0.GetLength(0), j];
                }
                else if (i < matrice0.GetLength(0) && j >= matrice0.GetLength(1))
                {
                    value = matrice2[i, j - matrice0.GetLength(1)];
                }
                else if (i >= matrice0.GetLength(0) && j >= matrice0.GetLength(1))
                {
                    value = matrice3[i - matrice0.GetLength(0), j - matrice0.GetLength(1)];
                }
                joinedMatrice[i, j] = value;
            }
        }
