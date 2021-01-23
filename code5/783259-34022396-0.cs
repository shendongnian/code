     private void Para()
        {
            int[, , ,] Result1 = new int[10, 10, 10, 10];
            int[, , ,] Result2 = new int[10, 10, 10, 10];
            int[, , ,] Result3 = new int[10, 10, 10, 10];
            int[, , ,] Result4 = new int[10, 10, 10, 10];
            Parallel.For(0L, 10, i =>
            {
                Parallel.For(0L, 10, j =>
                {
                    Parallel.For(0L, 10, k =>
                    {
                        Parallel.For(0L, 10, l =>
                        {
                            Result1[i, j, k, l] = myFunction1(i, j, k, l);
                            Result2[i, j, k, l] = myFunction2(i, j, k, l);
                            Result3[i, j, k, l] = myFunction3(i, j, k, l);
                            Result4[i, j, k, l] = myFunction4(i, j, k, l);
                        });
                    });
                });
            });
        }
