    [DllImport("coredll.dll")]
            private static extern int GetSystemMemoryDivision(ref int lpdwStorePages, ref int ldpwRamPages, ref int ldpwPageSize);
            [DllImport("coredll.dll")]
            private static extern int SetSystemMemoryDivision(int dwStorePages);
     public static void SetMemory(int division)
            {
                int storePages = 0;
                int ramPages = 0;
                int pageSize = 0;
                int totalPages = 0;
                if (GetSystemMemoryDivision(ref storePages, ref ramPages, ref pageSize) == 1)
                {
                    totalPages = storePages + ramPages;
                    storePages = Convert.ToInt32(totalPages * (100 - division) / 100);
                    SetSystemMemoryDivision(storePages);
                }
            }
